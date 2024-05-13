using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DistrictHeating
{
    /// <summary>
    /// Climate data on a hourly base, beginning at 1.1. 0 o'clock, exactely 8760 entries for each dataset, ignoring leap year
    /// </summary>
    public class Climate
    {
        public string? stationAndYear;
        /// <summary>
        /// Temperature in °C (TT_TU in dwd open data)
        /// </summary>
        internal double[] Temperature { get; set; } = new double[8760];
        /// <summary>
        /// Global solar radiation in J/m² (FG_LBERG in dwd open data)
        /// </summary>
        internal double[] GlobalSolarRadiation { get; set; } = new double[8760];
        /// <summary>
        /// diffuse solar radiation in J/m² (FD_LBERG in dwd open data)
        /// </summary>
        internal double[] DiffuseRadiation { get; set; } = new double[8760];
        public Climate()
        {   // initializing with data embeded in the resource
            LoadData(GetChoises()[0]);
        }
        public static Dictionary<int, double[]> ReadDwdData(StreamReader reader, string column)
        {
            Dictionary<int, double[]> yearToData = new Dictionary<int, double[]>();
            string? line = reader.ReadLine();
            if (line != null)
            {
                string[] title = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                int dateIndex = -1, valueIndex = -1;
                for (int i = 0; i < title.Length; i++)
                {
                    if (title[i].Contains("MESS_DATUM", StringComparison.InvariantCultureIgnoreCase)) dateIndex = i;
                    if (title[i].Contains(column, StringComparison.InvariantCultureIgnoreCase)) valueIndex = i;
                }
                if (dateIndex >= 0 && valueIndex >= 0)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length > dateIndex && parts.Length > valueIndex)
                        {
                            string date = parts[dateIndex];
                            if (date.Length >= 10)
                            {
                                try
                                {
                                    int year = Convert.ToInt32(date.Substring(0, 4));
                                    int month = Convert.ToInt32(date.Substring(4, 2));
                                    int day = Convert.ToInt32(date.Substring(6, 2));
                                    int hour = Convert.ToInt32(date.Substring(8, 2));
                                    if (year > 1800 && year < 2050 && month > 0 && month <= 12 && day > 0 && day <= 31 && hour >= 0 && hour < 24)
                                    {
                                        if (!yearToData.TryGetValue(year, out double[]? valuePerHour))
                                        {
                                            yearToData[year] = valuePerHour = new double[8760];
                                            for (int i = 0; i < valuePerHour.Length; i++)
                                            {
                                                valuePerHour[i] = 0;
                                            }
                                        }
                                        int hn = DateToHourNumber(month, day, hour);
                                        valuePerHour[hn] = Convert.ToDouble(parts[valueIndex], CultureInfo.InvariantCulture);
                                        if (valuePerHour[hn] == -999 && hn > 0) valuePerHour[hn] = valuePerHour[hn - 1]; // -999 is an error in data
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            return yearToData;
        }
        public static double[] ReadDwdData(StreamReader reader, string station, string year, string column)
        {
            double[] data = new double[8760];
            string? line = reader.ReadLine();
            if (line != null)
            {
                string[] title = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                int dateIndex = -1, valueIndex = -1, stationIndex = -1;
                for (int i = 0; i < title.Length; i++)
                {
                    if (title[i].Contains("MESS_DATUM", StringComparison.InvariantCultureIgnoreCase)) dateIndex = i;
                    if (title[i].Contains("STATIONS_ID", StringComparison.InvariantCultureIgnoreCase)) stationIndex = i;
                    if (title[i].Contains(column, StringComparison.InvariantCultureIgnoreCase)) valueIndex = i;
                }
                if (dateIndex >= 0 && valueIndex >= 0 && stationIndex >= 0)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length > dateIndex && parts.Length > valueIndex)
                        {
                            string date = parts[dateIndex];
                            if (date.Length >= 10)
                            {
                                try
                                {
                                    string yy = date.Substring(0, 4);
                                    int month = Convert.ToInt32(date.Substring(4, 2));
                                    int day = Convert.ToInt32(date.Substring(6, 2));
                                    int hour = Convert.ToInt32(date.Substring(8, 2));
                                    if (yy == year && month > 0 && month <= 12 && day > 0 && day <= 31 && hour >= 0 && hour < 24)
                                    {
                                        int hn = DateToHourNumber(month, day, hour);
                                        data[hn] = Convert.ToDouble(parts[valueIndex].Replace(',','.'), CultureInfo.InvariantCulture);
                                        if (data[hn] == -999 && hn > 0) data[hn] = data[hn - 1]; // -999 is an error in data
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            return data;
        }
        public static string[] GetChoises()
        {
            string[] res = new string[]
            {
                "3987 Potsdam 2023",
                "5100 Trier 2023",
                "1580 Geisenheim 2000",
                "1580 Geisenheim 2001",
                "1580 Geisenheim 2002",
                "1580 Geisenheim 2003",
                "1580 Geisenheim 2004",
                "1580 Geisenheim 2005",
                "1580 Geisenheim 2006",
                "1580 Geisenheim 2008",
                "1580 Geisenheim 2009",
                "1580 Geisenheim 2010",
                "1580 Geisenheim 2011",
                "1580 Geisenheim 2012",
                "1580 Geisenheim 2013"
            };
            return res;
        }
        public bool LoadData(string? name)
        {
            if (name == stationAndYear) return true;
            stationAndYear = name;
            string[] parts = name.Split(' ');
            Assembly ThisAssembly = Assembly.GetExecutingAssembly();
            System.IO.Stream? str = ThisAssembly.GetManifestResourceStream("DistrictHeating.TemperatureData.txt");
            if (str != null)
            {
                using (StreamReader reader = new StreamReader(str))
                {
                    Temperature = ReadDwdData(reader, parts[0], parts[2], "TT_TU");
                }
            }
            str = ThisAssembly.GetManifestResourceStream("DistrictHeating.SolarData.txt");
            if (str != null)
            {
                using (StreamReader reader = new StreamReader(str))
                {
                    GlobalSolarRadiation = ReadDwdData(reader, parts[0], parts[2], "FG_LBERG");
                }
                // str.Position = 0; // cannot acces closed stream
                str = ThisAssembly.GetManifestResourceStream("DistrictHeating.SolarData.txt");
                using (StreamReader reader = new StreamReader(str))
                {
                    DiffuseRadiation = ReadDwdData(reader, parts[0], parts[2], "FD_LBERG");
                }
            }
            return Temperature != null && GlobalSolarRadiation != null && DiffuseRadiation != null;
        }
        /*
         */
        /// <summary>
        /// Converts a date to the number of the hour in the year [0..8759]
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        internal static int DateToHourNumber(int month, int day, int hour)
        {   // don't care about leap year
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int res = 0;
            for (int i = 1; i < month; i++)
            {
                res += 24 * months[i - 1];
            }
            res += (day - 1) * 24 + hour;
            return res;
        }
        public static int HourNumberToMonth(int hour)
        {
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 0; i < 12; i++)
            {
                hour -= months[i] * 24;
                if (hour < 0) return i;
            }
            return 11;
        }
        public static (int month, int day, int hour) HourNumberToDate(int hour)
        {
            if (hour > 365 * 24) hour -= 365 * 24;
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int m = 11;
            int d = 0;
            int h = 0;
            for (int i = 0; i < 12; i++)
            {
                hour -= months[i] * 24;
                if (hour < 0)
                {
                    m = i;
                    hour += months[i] * 24;
                    break;
                }
            }
            // now hour contains number of hours in this month
            d = hour / 24;
            h = hour % 24;
            return (m + 1, d + 1, h);
        }
        public double GetTempBelow(double threshold)
        {   // TODO: use cache
            double res = 0.0;
            for (int i = 0; i < Temperature.Length; i++)
            {
                if (Temperature[i] < threshold) res += threshold - Temperature[i];
            }
            return res;
        }

    }
}
