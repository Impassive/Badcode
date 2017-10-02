using System;
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
            next = seed * Math.PI;
        }

        public double Next(int interval)
        {
            next += next % (interval * Math.E)+(int)(DateTime.Now.Millisecond);
            return next % (interval - (-interval) + 1) + (-interval);
        }
    }

    public class Analysis
    {
        public Analysis(DataPointCollection data)
        {
            //среднее
            double calculated_avg = 0;
            calculated_avg = Calculate_avg(data);
            //среднеквадратичное
            double calculated_rms = 0;
            calculated_rms = Calculate_rms(data);
            //дисперсия
            double calculated_dispersion = 0;
            calculated_dispersion = Calculate_dispersion(data,2);
            //среднеквадратичное отклонение
            double calculated_standard_deviation = Math.Sqrt(Calculate_dispersion(data,2));
        }
        //Среднее
        public static double Calculate_avg(DataPointCollection data)
        {
            double sumX = 0;
            int counter = 0;
            foreach (var point in data)
            {
                sumX += point.YValues[0];
                counter++;
            }
            return (double)(sumX / counter);
        }
        //Среднеквадратичное
        public static double Calculate_rms(DataPointCollection data)
        {
            double sumX = 0;
            int counter = 0;
            foreach (var point in data)
            {
                sumX += Math.Pow(point.YValues[0], 2);
                counter++;
            }
            return (double)(sumX / counter);
        }
        //Дисперсия
        public static double Calculate_dispersion(DataPointCollection data, int pow)
        {
            int counter = 0;
            double avg = 0;
            double dispersion = 0;
            avg = Calculate_avg(data);
            foreach (var point in data)
            {
                dispersion += Math.Pow(point.YValues[0] - avg, pow);
                counter++;
            }
            return dispersion / counter;
        }
        //Стандартное отклонение
        public static double Calculate_standard_deviation(DataPointCollection data)
        {
            return Math.Sqrt(Calculate_dispersion(data,2));
        }
        //Среднее отклонение (сигма?)
        public static double Calculate_avg_deviation(DataPointCollection data)
        {
            return Math.Sqrt(Calculate_rms(data));
        }
        //Асимметрия
        public static double Calculate_asymmetry(DataPointCollection data)
        {
            return (Calculate_dispersion(data, 3))/ Math.Pow(Calculate_standard_deviation(data),3);
        }
        //Эксцесс
        public static double Calculate_kurtosis(DataPointCollection data)
        {
            return (Calculate_dispersion(data, 4)) / Math.Pow(Calculate_standard_deviation(data), 4);
        }
    }

}
