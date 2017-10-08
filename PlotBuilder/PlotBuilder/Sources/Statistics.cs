using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotBuilder.Sources
{
    public static class Statistics
    {

        //Собрать статистику
        public static string GetStatistics(DataPointCollection points, bool stationarity = false, bool correlation = false)
        {
            string message = "";
            if (!correlation)
            {
                message = "Среднее: " + Math.Round(CalcAVG(points), 2) + "\n";
                message += "СК: " + Math.Round(CalcRMS(points), 2) + "\n";
                message += "Дисперсия: " + Math.Round(CalcDispersion(points), 2) + "\n";
                message += "СКО: " + Math.Round(CalcStandardDeviation(points), 2) + "\n";
                message += "СО: " + Math.Round(CalcAvgDeviation(points), 2) + "\n";
                message += "3-ий момент: " + Math.Round(CalcDispersion(points, 3), 2) + "\n";
                message += "4-ый момент: " + Math.Round(CalcDispersion(points, 4), 2) + "\n";
                message += "Асимметрия: " + Math.Round(CalcAsymmetry(points), 2) + "\n";
                message += "Эксцесс: " + Math.Round(CalcKurtosis(points), 2) + "\n";
                if (stationarity)
                {
                    message += "Стационарность (avg): " + Math.Round(CalcStatMean(points), 2) + "\n";
                    message += "Стационраность (dispersion): " + Math.Round(CalcStatDispersion(points), 2) + "\n";
                }
            }
            return message;
        }
        //Среднее
        private static double CalcAVG(DataPointCollection points)
        {
            double sum = 0;
            foreach (var point in points)
            {
                sum += point.YValues[0];
            }
            return (double)(sum / points.Count);
        }
        //Среднеквадратичное
        private static double CalcRMS(DataPointCollection points)
        {
            double sum = 0;
            foreach (var point in points)
            {
                sum += Math.Pow(point.YValues[0], 2);
            }
            return (double)(sum / points.Count);
        }
        //Дисперсия
        private static double CalcDispersion(DataPointCollection points, int pow = 2)
        {
            double avg = 0;
            double dispersion = 0;
            avg = CalcAVG(points);
            foreach (var point in points)
            {
                dispersion += Math.Pow(point.YValues[0] - avg, pow);
            }
            return dispersion / points.Count;
        }
        //Стандартное отклонение
        private static double CalcStandardDeviation(DataPointCollection points)
        {
            return Math.Sqrt(CalcDispersion(points, 2));
        }
        //Среднее отклонение (сигма?)
        private static double CalcAvgDeviation(DataPointCollection points)
        {
            return Math.Sqrt(CalcRMS(points));
        }
        //Асимметрия
        private static double CalcAsymmetry(DataPointCollection points)
        {
            return (CalcDispersion(points, 3)) / Math.Pow(CalcStandardDeviation(points), 3);
        }
        //Эксцесс
        private static double CalcKurtosis(DataPointCollection points)
        {
            return (CalcDispersion(points, 4)) / Math.Pow(CalcStandardDeviation(points), 4);
        }
        //Корреляция
        public static double CrossCorrelation(DataPointCollection pointsFirst, DataPointCollection pointsSecond, int lag)
        {
            double pointsFirstAVG = CalcAVG(pointsFirst);
            double pointsSecondAVG = CalcAVG(pointsSecond);
            double sum = 0;
            for (int i = 0; i < (pointsFirst.Count - lag); i++)
            {
                sum += (pointsFirst[i].YValues[0] - pointsFirstAVG) * (pointsSecond[i + lag].YValues[0] - pointsSecondAVG);
            }
            return sum / ((pointsFirst.Count - lag) * (CalcStandardDeviation(pointsFirst) * CalcStandardDeviation(pointsSecond)));
        }
        //Стационарность (по среднему)
        private static double CalcStatMean(DataPointCollection points, int statDelimiter = 10)
        {
            Series s = new Series();
            int block = (int)(points.Count / statDelimiter);
            double[] sum = new double[statDelimiter];
            for (int i = 0; i < statDelimiter; i++)
            {
                s.Points.Clear();
                for (int j = i * block; j < (i + 1) * block; j++)
                {
                    s.Points.AddXY(points[j].XValue, points[j].YValues[0]);
                }
                sum[i] = CalcAVG(s.Points);
            }
            s.Dispose();
            double min = sum.Min();
            double avg = sum.Average();
            double max = sum.Max();
            return (max - avg) * 100 / max;
        }
        //Стационарность (по дисперсии)
        private static double CalcStatDispersion(DataPointCollection points, int statDelimiter = 10)
        {
            Series s = new Series();
            int block = (int)(points.Count / statDelimiter);
            double[] sum = new double[statDelimiter];
            for (int i = 0; i < statDelimiter; i++)
            {
                s.Points.Clear();
                for (int j = i * block; j < (i + 1) * block; j++)
                {
                    s.Points.AddXY(points[j].XValue, points[j].YValues[0]);
                }
                sum[i] = Math.Round(CalcDispersion(s.Points, 2), 2);
            }
            s.Dispose();
            double min = sum.Min();
            double avg = sum.Average();
            double max = sum.Max();
            return (max - avg) * 100 / max;
        }
    }
}
