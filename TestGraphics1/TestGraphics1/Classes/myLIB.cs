﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestGraphics
{
    public class Custom_random
    {
        private double next = 0;
        public Custom_random(int seed = 55)
        {
            next = seed % Math.PI;
        }

        public double Next(int interval)
        {
            next += next % (interval * Math.E) + (int)(DateTime.Now.Millisecond);
            return 0 + ((next % 100) / 100) * (interval - 0);
        }
    }

    public static class Analysis
    {
        //Среднее
        public static double Calculate_avg(DataPointCollection data)
        {
            double sum = 0;
            foreach (var point in data)
            {
                sum += point.YValues[0];
            }
            return (double)(sum / data.Count);
        }
        //Среднеквадратичное
        public static double Calculate_rms(DataPointCollection data)
        {
            double sum = 0;
            foreach (var point in data)
            {
                sum += Math.Pow(point.YValues[0], 2);
            }
            return (double)(sum / data.Count);
        }
        //Дисперсия
        public static double Calculate_dispersion(DataPointCollection data, int pow)
        {
            double avg = 0;
            double dispersion = 0;
            avg = Calculate_avg(data);
            foreach (var point in data)
            {
                dispersion += Math.Pow(point.YValues[0] - avg, pow);
            }
            return dispersion / data.Count;
        }
        //Стандартное отклонение
        public static double Calculate_standard_deviation(DataPointCollection data)
        {
            return Math.Sqrt(Calculate_dispersion(data, 2));
        }
        //Среднее отклонение (сигма?)
        public static double Calculate_avg_deviation(DataPointCollection data)
        {
            return Math.Sqrt(Calculate_rms(data));
        }
        //Асимметрия
        public static double Calculate_asymmetry(DataPointCollection data)
        {
            return (Calculate_dispersion(data, 3)) / Math.Pow(Calculate_standard_deviation(data), 3);
        }
        //Эксцесс
        public static double Calculate_kurtosis(DataPointCollection data)
        {
            return (Calculate_dispersion(data, 4)) / Math.Pow(Calculate_standard_deviation(data), 4);
        }
        public static int[] prepare_gist_data(DataPointCollection data, int delimiter)
        {
            double[] arr = new double[MainForm.N];
            arr = data.Select(y => y.YValues[0]).ToArray();
            double minY = arr.Min();
            double maxY = arr.Max();
            double block = (maxY - minY) / delimiter;
            int[] gist = new int[delimiter];

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
            return gist;
        }

        public static double Calculate_cross_correlation(DataPointCollection data1, DataPointCollection data2, int lag)
        {
            double avg_1 = Calculate_avg(data1);
            double avg_2 = Calculate_avg(data2);
            double sum = 0;
            for (int i = 0; i < data1.Count - lag && i < data2.Count - lag; i++)
            {
                sum += (data1[i].YValues[0] - avg_1) * (data2[i + lag].YValues[0] - avg_2);
            }
            return sum / data1.Count;
        }
    }
}

