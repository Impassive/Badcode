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
        //Среднее
        public static double CalcAVG(DataPointCollection points)
        {
            double sum = 0;
            foreach (var point in points)
            {
                sum += point.YValues[0];
            }
            return (double)(sum / points.Count);
        }
        //Дисперсия
        public static double CalcDispersion(DataPointCollection points, int pow)
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
        public static double CalcStandardDevieation(DataPointCollection points)
        {
            return Math.Sqrt(CalcDispersion(points, 2));
        }
        public static double CrossCorrelation(DataPointCollection pointsFirst, DataPointCollection pointsSecond, int lag)
        {
            double pointsFirstAVG = CalcAVG(pointsFirst);
            double pointsSecondAVG = CalcAVG(pointsSecond);
            double sum = 0;
            for (int i = 0; i < (pointsFirst.Count - lag); i++)
            {
                sum += (pointsFirst[i].YValues[0] - pointsFirstAVG) * (pointsSecond[i + lag].YValues[0] - pointsSecondAVG);
            }
            return sum / ((pointsFirst.Count - lag) * (CalcStandardDevieation(pointsFirst) * CalcStandardDevieation(pointsSecond)));
        }
    }
}
