﻿using System;
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
        internal static int a { get; set; }
        internal static int b { get; set; }
        static Plots()
        {
            minX = 0;
            maxX = 40;
            minY = 0;
            maxY = 10;
        }
        internal static void Trends(DataPointCollection points, string location, double a = 1, double b = 0)
        {
            switch (location)
            {
                case "ChartAreaTopLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, a * i + b);
                    }
                    break;
                case "ChartAreaTopRight":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, a * i + b);
                    }
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, b * Math.Pow(Math.E, (-a) * i));
                    }
                    break;
                case "ChartAreaBottomRight":
                    points.Clear();
                    for (int i = minX; i < maxX - 5; i++)
                    {
                        points.AddXY(i, b * Math.Pow(Math.E, (-a) * i));
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Procedure to build random graphics
        /// </summary>
        /// <param name="points">series to fill</param>
        /// <param name="location">in which chartarea build</param>
        /// <param name="seed">seed for random initialization</param>
        internal static void Random(DataPointCollection points, string location, int seed = 1)
        {
            Random r = new Random(seed);
            CustomRandom cr = new CustomRandom(seed);
            switch (location)
            {
                case "ChartAreaTopLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, r.NextDouble());
                    }
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, cr.Next());
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Procedure to build Correlation graphic
        /// </summary>
        /// <param name="points">result series where graphic will build</param>
        /// <param name="pointsFirst">first series to correlate</param>
        /// <param name="pointsSecond">second series to correlate</param>
        internal static void AutoCrossCorrelation(DataPointCollection points, DataPointCollection pointsFirst, DataPointCollection pointsSecond)
        {
            points.Clear();
            for (int i = minX; i < maxX; i++)
            {
                points.AddXY(i, Statistics.CrossCorrelation(pointsFirst, pointsSecond, i));
            }
        }

        internal static void Gist(DataPointCollection result, DataPointCollection pointsSource, int gistDelimiter = 10)
        {
            double[] arr = new double[result.Count];
            arr = pointsSource.Select(y => y.YValues[0]).ToArray();
            double minY = arr.Min();
            double maxY = arr.Max();
            //Разброс значений
            double block = (maxY - minY) / gistDelimiter;
            int[] gist = new int[gistDelimiter];
            foreach (var p in arr)
            {
                try
                {
                    gist[(int)(Math.Truncate((p - minY) / block))]++;
                }
                catch
                {
                    gist[gist.Length - 1]++;
                }
            }
            for (int i = 0; i < gist.Length; i++)
            {
                result.AddXY(i, gist[i]);
            }
        }
    }
}


