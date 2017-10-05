using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotBuilder.Sources
{
    public static class Plots
    {
        internal static int minX { get; set; }
        internal static int maxX { get; set; }
        internal static int minY { get; set; }
        internal static int maxY { get; set; }
        static Plots()
        {
            minX = 0;
            maxX = 1000;
            minY = 0;
            maxY = 100;
        }
        internal static void Trends(DataPointCollection points, string location)
        {
            switch (location)
            {
                case "ChartAreaTopLeft":
                    points.Clear();
                    for (int i = 0; i < minX; i++)
                    {
                        points.AddXY
                    }
                    break;
                case "ChartAreaTopRight":
                    points.Clear();
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    break;
                case "ChartAreaBottomRight":
                    points.Clear();
                    break;
                default:
                    break;
            }
        }

    }

}
