using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DistrictHeating
{
    public static class HelpInfo
    {
        public static Dictionary<string,string> HelpItem { get; private set; }

        static HelpInfo()
        {
            HelpItem = new Dictionary<string,string>();
            string resourceName = "DistrictHeating.HelpInfo.txt";

            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Resource not found. Please check the embedded resource name.");
                }
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string text = reader.ReadToEnd() + "\r\n---end"; 
                    string[] lines = text.Split("\r\n");
                    string? lastKey = null;
                    string lastValue = "";
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith("---"))
                        {
                            if (lastKey!=null && !string.IsNullOrEmpty(lastValue))
                            {
                                HelpItem[lastKey] = lastValue;
                            }
                            lastKey = lines[i].Substring(3).TrimEnd(':');
                            lastValue = "";
                        }
                        else
                        {
                            lastValue = lastValue + lines[i] + "\r\n";
                        }
                    }
                }
            }
        }

        internal static string? Item(string key)
        {
            if (HelpItem.TryGetValue(key, out string? value)) return value;
            return null;
        }
    }
}
