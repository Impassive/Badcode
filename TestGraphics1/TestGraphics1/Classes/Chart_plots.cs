using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestGraphics
{
    public class Chart_plots
    {
        public Chart_plots()
        {
            
        }

        public static void chart_graph_1(int a, int b)
        {
            MainForm.title.Text = "y=ax+b";
            for (double x = 0; x <= MainForm.N; x += 1)
            {
                MainForm.series.Points.AddXY(x, a * x + b);
            }
        }

        public static void chart_graph_2(double a, int b)
        {
            MainForm.title.Text = "y=be^(-ax), a>0";
            for (double x = 0.1; x <= MainForm.N; x += 1)
            {
                MainForm.series.Points.AddXY(x, b * Math.Pow(Math.E, (-a) * x));
            }
        }
        public static void chart_graph_3(double a, int b)
        {
            MainForm.title.Text = "Custom";
            for (double x = 0.1; x <= MainForm.N; x += 1)
            {
                MainForm.series.Points.AddXY(x, Math.Pow(x, 2));
            }
            for (double x = MainForm.N * 0.2; x <= MainForm.N * 0.7; x += 1)
            {
                MainForm.series.Points.AddXY(x, x);
            }
            for (double x = MainForm.N * 0.7; x <= MainForm.N; x += 1)
            {
                MainForm.series.Points.AddXY(x, a + b * Math.Cos(x));
            }
        }
        public static void chart_graph_random(int seed, bool rnd_flag)
        {
            if (rnd_flag == false)
            {
                MainForm.title.Text = "Random";
                //Randomize 
                Random ry = new Random(seed);
                for (double x = 0; x < MainForm.N / 2; x += 1)
                {
                    MainForm.series.Points.AddXY(x, Math.Cos(ry.Next()));
                }
            }
            else
            {
                MainForm.title.Text = "Custom Random";
                Custom_random r = new Custom_random(seed);
                for (double x = 0; x < MainForm.N / 2; x += 1)
                {
                    MainForm.series.Points.AddXY(x, r.Next(seed));
                }
            }
        }
        public static void prepare_gist(int[] gist)
        {
            for (int i=0; i< gist.Length; i++)
            {
                MainForm.series.Points.AddXY(i,gist[i]);
            }
        }
    }
}
