using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistrictHeating
{
    public class PaintDiagram
    {
        Panel diagram;
        Panel left;
        Panel right;
        Plant plant;

        float horLineDiff;
        public PaintDiagram(Panel diagram, Panel left, Panel right, Plant plant)
        {
            this.diagram = diagram;
            this.left = left;
            this.right = right;
            this.plant = plant;

            horLineDiff = diagram.Height / 13; // hardcoded 12 horizontal lines
        }

        private float HorLinePosition(int ind)
        {
            return (12 - ind) * horLineDiff;
        }

        private void ShowScale(bool leftSide, int offset, int lowestValue, int highestValue, string suffix)
        {
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Graphics toDrawOn;
            if (leftSide) toDrawOn=left.CreateGraphics();
            else toDrawOn = right.CreateGraphics();
            using (toDrawOn)
            {
                toDrawOn.Clear(Color.White);
                for (int i = 0; i < 12; i++)
                {
                    int val = lowestValue + i * (highestValue - lowestValue) / 12;
                    toDrawOn.DrawString(val.ToString() + suffix, SystemFonts.DefaultFont, Brushes.Red, new PointF(left.Width / 2.0f, HorLinePosition(i)), centerFormat);
                }
            }
        }
        public void Paint()
        {
            using (Graphics grDiagram = diagram.CreateGraphics())
            {
                grDiagram.Clear(Color.White);
                for (int i = 0; i < 12; i++)
                {
                    grDiagram.DrawLine(Pens.LightGray, 0, HorLinePosition(i), diagram.Width, HorLinePosition(i));
                }
                ShowScale(true, 0, -20, 100, "°C");
            }
        }
    }
}
