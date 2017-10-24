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
        //internal static int a { get; set; }
        //internal static int b { get; set; }
        internal static int border { get; set; }
        internal static double delta { get; set; }
        internal static double[] imp;
        internal static double[] temp;
        static Plots()
        {
            border = 1;
            minX = 0;
            maxX = 500;
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

        internal static void Discretization(DataPointCollection points, string location, double a = 1, double d = 0.001)
        {
            switch (location)
            {
                case "ChartAreaTopLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, a * 100 * Math.Sin(10 * Math.PI * 57 * i * d));
                    }
                    break;
                case "ChartAreaTopRight":
                    points.Clear();
                    for (double i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, ((a * 20 * Math.Sin(2 * Math.PI * 5 * i * d)) + (a * 100 * Math.Sin(2 * Math.PI * 57 * i * d)) + (a * 35 * Math.Sin(2 * Math.PI * 190 * i * d))));
                    }
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    for (double i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, ((a * 20 * Math.Sin(2 * Math.PI * 5 * i * d)) + (a * 100 * Math.Sin(2 * Math.PI * 57 * i * d)) + (a * 35 * Math.Sin(2 * Math.PI * 190 * i * d))));
                    }
                    break;
            }
        }

        //случайной точке увеличиваем значение на сигму
        internal static void Spike(DataPointCollection points, double chance = 0.5, double sigma = 10000)
        {
            Random r = new Random(400);
            foreach (var point in points)
            {
                if (r.NextDouble() < chance)
                {
                    point.YValues[0] += sigma;
                }
            }
        }
        internal static void Shift(DataPointCollection points, double c = 1)
        {
            foreach (var point in points)
            {
                point.YValues[0] += c;
            }
        }

        public class Complex
        {
            public double Re = 0;
            public double Im = 0;
            public double C = 0;
        }

        public static Complex[] FourierArr;
        public static double SignalFunc(double A, double f, int step)
        {
            return A * Math.Sin(2 * Math.PI * f * delta * step);
        }
        public static void PrepareDPF(DataPointCollection points)
        {
            //Generate function 

            points.Clear();
            for (int i = minX; i < maxX; i++)
            {
                points.AddXY(i, SignalFunc(20, 5, i) + SignalFunc(100, 57, i) + SignalFunc(35, 190, i));
            }
            //Calculating
            FourierArr = new Complex[points.Count];
            CalculateDPF(FourierArr, points);
        }
        public static double CalculateBorder(double Delta)
        {
            delta = Delta;
            return 1 / (2 * delta);
        }
        public static void DPF(DataPointCollection points, string location)
        {
            switch (location)
            {
                case "ChartAreaTopLeft":
                    break;
                case "ChartAreaTopRight":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, FourierArr[i].C);
                    }
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    for (int i = minX; i < maxX; i++)
                    {
                        points.AddXY(i, FourierArr[i].Re);
                    }
                    break;
                case "ChartAreaBottomRight":
                    points.Clear();
                    for (int i = minX; i < maxX - 5; i++)
                    {
                        points.AddXY(i, FourierArr[i].Im);
                    }
                    break;
                default:
                    break;
            }
        }
        private static void CalculateDPF(Complex[] FourierArr, DataPointCollection points)
        {
            int N = points.Count;
            double arg = 0;

            for (int i = minX; i < maxX; i++)
            {
                FourierArr[i] = new Complex();
                int j = 0;
                foreach (var point in points)
                {
                    arg = 2 * Math.PI * i * j / N;
                    FourierArr[i].Re += point.YValues[0] * Math.Cos(arg);
                    FourierArr[i].Im += point.YValues[0] * Math.Sin(arg);
                    j++;
                }
                FourierArr[i].C = Math.Sqrt(Math.Pow(FourierArr[i].Re, 2) + Math.Pow(FourierArr[i].Im, 2));
            }
        }
        internal static void Impulse(DataPointCollection points, string location, double d = 0.005, double alpha = 45, int _m = 200)
        {
            //build charts:
            switch (location)
            {
                case "ChartAreaTopLeft":
                    points.Clear();
                    _m = maxX;
                    temp = new double[_m];
                    for (int i = minX; i < maxX; i++)
                    {
                        temp[i] = 2 * Math.Sin(2 * Math.PI * 14 * i * d) * Math.Pow(Math.E, -alpha * d * i);
                        points.AddXY(i, temp[i]);
                    }
                    break;
                case "ChartAreaTopRight":
                    points.Clear();
                    for (int k = minX; k < maxX; k++)
                    {
                        double y = 0;
                        for (int l = minX; l < _m; l++)
                        {
                            if (k >= l && (k - l) < imp.Length)
                                y += imp[k - l] * temp[l];
                        }
                        points.AddXY(k, y);
                    }
                    break;
                case "ChartAreaBottomLeft":
                    points.Clear();
                    imp = new double[maxX];
                    for (int i = minX; i < maxX; i++)
                    {
                        if (i % 200 == 0 && i > 1)
                        {
                            points.AddXY(i, 1);
                            imp[i] = 120;
                        }
                        else
                        {
                            points.AddXY(i, 0);
                            imp[i] = 0;
                        }
                    }
                    break;
                case "ChartAreaBottomRight":
                    points.Clear();

                    break;
                default:
                    break;
            }
        }

        private static void ImpulseReaction(int m)
        {

        }
    }

}


