using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PlotBuilder;
using System.Drawing;
using System.ComponentModel;

namespace PlotBuilder.Sources
{
    public class ManageChart
    {
        private Chart chart = new Chart();
        private ToolTip tooltip = new ToolTip();
        private Font mainFont = new Font("Font", 20);
        private Font font = new Font("Font", 14, FontStyle.Bold, GraphicsUnit.World);
        private Title mainTitle = new Title();
        private Title titleTopLeft = new Title();
        private Title titleTopRight = new Title();
        private Title titleBottomLeft = new Title();
        private Title titleBottomRight = new Title();
        private ChartArea chartAreaTopLeft = new ChartArea("ChartAreaTopLeft");
        private ChartArea chartAreaTopRight = new ChartArea("ChartAreaTopRight");
        private ChartArea chartAreaBottomLeft = new ChartArea("ChartAreaBottomLeft");
        private ChartArea chartAreaBottomRight = new ChartArea("ChartAreaBottomRight");
        private Series seriesTopLeft = new Series("seriesTopLeft", 1);
        private Series seriesTopRight = new Series("seriesTopRight", 1);
        private Series seriesBottomLeft = new Series("seriesBottomLeft", 1);
        private Series seriesBottomRight = new Series("seriesBottomRight", 1);
        private string messageTopLeft { get; set; }
        private string messageTopRight { get; set; }
        private string messageBottomLeft { get; set; }
        private string messageBottomRight { get; set; }
        public ManageChart(GroupBox gbox)
        {
            chartInit();
            toolTipInit();
            gbox.Controls.Add(chart);

            //TO TEST PURPOSE
            messageTopLeft = "top LEFT";
            messageTopRight = "top RIGHT";
            messageBottomLeft = "bottom LEFT";
            messageBottomRight = "bottom RIGHT";
        }
        public void toolTipInit()
        {
            tooltip.Active = false;
            tooltip.InitialDelay = 0;
            tooltip.UseAnimation = true;
            tooltip.ShowAlways = true;
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.AutoPopDelay = 20000;
            tooltip.ReshowDelay = 750;
            tooltip.ToolTipTitle = "Analytics:";
            tooltip.SetToolTip(chart, "Computing");
        }
        /// <summary>
        /// set chart initialization params
        /// </summary>
        public void chartInit()
        {
            //set chart areas

            //set titles
            //main title
            mainTitle.Docking = Docking.Top;
            mainTitle.Font = mainFont;
            mainTitle.Text = "Hello!";
            //fill title Top Left
            titleTopLeft.Docking = Docking.Top;
            titleTopLeft.Font = font;
            titleTopLeft.Alignment = ContentAlignment.TopCenter;
            titleTopLeft.Text = "Hello left top!";
            titleTopLeft.DockedToChartArea = "ChartAreaTopLeft";
            //fill title Top Right
            titleTopRight.Docking = Docking.Top;
            titleTopRight.Font = font;
            titleTopRight.Alignment = ContentAlignment.TopCenter;
            titleTopRight.Text = "Hello right top!";
            titleTopRight.DockedToChartArea = "ChartAreaTopRight";
            //fill title Bottom Left
            titleBottomLeft.Docking = Docking.Top;
            titleBottomLeft.Font = font;
            titleBottomLeft.Alignment = ContentAlignment.TopCenter;
            titleBottomLeft.Text = "Hello left bot!";
            titleBottomLeft.DockedToChartArea = "ChartAreaBottomLeft";
            //fill title Bottom Right
            titleBottomRight.Docking = Docking.Top;
            titleBottomRight.Font = font;
            titleBottomRight.Alignment = ContentAlignment.TopCenter;
            titleBottomRight.Text = "Hello right bot!";
            titleBottomRight.DockedToChartArea = "ChartAreaBottomRight";

            //Set Series
            //Top Left series
            seriesTopLeft.ChartArea = "ChartAreaTopLeft";
            //Top Right series
            seriesTopRight.ChartArea = "ChartAreaTopRight";
            //Bottom Left series
            seriesBottomLeft.ChartArea = "ChartAreaBottomLeft";
            //Bottom Right series
            seriesBottomRight.ChartArea = "ChartAreaBottomRight";

            //Set chart params
            chart.ChartAreas.Add(chartAreaTopLeft);
            chart.ChartAreas.Add(chartAreaBottomLeft);
            chart.ChartAreas.Add(chartAreaTopRight);
            chart.ChartAreas.Add(chartAreaBottomRight);
            chart.Titles.Add(mainTitle);
            chart.Titles.Add(titleTopLeft);
            chart.Titles.Add(titleTopRight);
            chart.Titles.Add(titleBottomLeft);
            chart.Titles.Add(titleBottomRight);
            chart.Series.Add(seriesTopLeft);
            chart.Series.Add(seriesTopRight);
            chart.Series.Add(seriesBottomLeft);
            chart.Series.Add(seriesBottomRight);
            chart.Dock = DockStyle.Fill;
            chart.MouseClick += Chart_MouseClick;
            //disable margin on graphics
            foreach (var chartAreas in chart.ChartAreas)
            {
                chartAreas.AxisX.IsMarginVisible = false;
                chartAreas.AxisX.ScaleView.Zoomable = true;
                chartAreas.AxisY.ScaleView.Zoomable = true;
                chartAreas.CursorX.IsUserEnabled = true;
                chartAreas.CursorX.IsUserSelectionEnabled = true;
                chartAreas.CursorY.IsUserEnabled = true;
                chartAreas.CursorY.IsUserSelectionEnabled = true;
            }
        }


        //Event that represents tooltip text with chart area
        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            tooltip.RemoveAll();
            tooltip.Active = true;
            if (e.X > chart.Location.X && e.X < chart.Location.X + chart.Size.Width / 2)
            {
                //left panel
                if (e.Y > chart.Location.Y && e.Y < chart.Location.Y + chart.Size.Height / 2)
                {
                    tooltip.SetToolTip(chart, messageTopLeft);
                }
                else
                {
                    tooltip.SetToolTip(chart, messageBottomLeft);
                }
            }
            else
            {
                //right panel
                if (e.Y > chart.Location.Y && e.Y < chart.Location.Y + chart.Size.Height / 2)
                {
                    tooltip.SetToolTip(chart, messageTopRight);
                }
                else
                {
                    tooltip.SetToolTip(chart, messageBottomRight);
                }
            }
        }
        public void Update()
        {
            foreach (var series in chart.Series)
                series.BorderWidth = Plots.border;
            chart.Update();
        }
        private void pointsClear()
        {
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = Plots.maxX;
                area.AxisX.Minimum = Plots.minX;
            }
        }

        public void chartBuildTrends()
        {
            pointsClear();
            mainTitle.Text = "Trends";
            //fill top left series
            titleTopLeft.Text = "y=ax+b";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Trends(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points);
            //fill top right series
            titleTopRight.Text = "y=(-a)x+b";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Trends(seriesTopRight.Points, seriesTopRight.ChartArea);
            messageTopRight = Statistics.GetStatistics(seriesTopRight.Points);
            //fill bottom left series
            titleBottomLeft.Text = "y=be^(-ax)";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Trends(seriesBottomLeft.Points, seriesBottomLeft.ChartArea, 0.1, 1);
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points);
            //fill bottom right series
            titleBottomRight.Text = "y=be^(ax)";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Trends(seriesBottomRight.Points, seriesBottomRight.ChartArea, 0.1, 0.1);
            messageBottomRight = Statistics.GetStatistics(seriesBottomRight.Points);
        }

        public void chartBuildRandomAndAutoCorrelation()
        {
            pointsClear();
            mainTitle.Text = "Random & Auto Correlation";
            //fill top left series 
            titleTopLeft.Text = "Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points, true);
            //fill top right series - Auto correlation for top left
            titleTopRight.Text = "Auto Correlation";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.DashDot;
            Plots.AutoCrossCorrelation(seriesTopRight.Points, seriesTopLeft.Points, seriesTopLeft.Points);
            messageTopRight = "Auto Correlation";
            //fill bottom left series
            titleBottomLeft.Text = "Custom";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points, true);
            //fill bottom right series - Auto correlation for bottom left
            titleBottomRight.Text = "Auto Correlation";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.DashDot;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesBottomLeft.Points, seriesBottomLeft.Points);
            messageBottomRight = "Auto Correlation";
        }

        public void chartBuildRandomAndCrossCorrelation()
        {
            pointsClear();
            mainTitle.Text = "Random & Cross Correlation";
            //fill top left series 
            titleTopLeft.Text = "Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points, true);
            //fill bottom left series
            titleBottomLeft.Text = "Custom";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points, true);
            //fill top right series - Auto correlation for top left
            titleTopRight.Text = "Random-custom Cross Correlation";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.DashDot;
            Plots.AutoCrossCorrelation(seriesTopRight.Points, seriesTopLeft.Points, seriesBottomLeft.Points);
            messageTopRight = "Auto Correlation";
            //fill bottom right series - Auto correlation for bottom left
            titleBottomRight.Text = "Custom-random Cross Correlation";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.DashDot;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesBottomLeft.Points, seriesTopLeft.Points);
            messageBottomRight = "Auto Correlation";
        }

        public void chartBuildRandomAndGist()
        {
            pointsClear();
            mainTitle.Text = "Random & Gist";
            //fill top left series 
            titleTopLeft.Text = "Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points, true);
            //fill bottom left series
            titleBottomLeft.Text = "Custom";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Random(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points, true);
            //fill top right series - gist of top left
            titleTopRight.Text = "Random Gist";
            seriesTopRight.ChartType = SeriesChartType.Column;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Gist(seriesTopRight.Points, seriesTopLeft.Points);
            messageTopRight = "Random gist";
            //fill bottom right series - gist of bottom left
            titleBottomRight.Text = "Custom Gist";
            seriesBottomRight.ChartType = SeriesChartType.Column;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Gist(seriesBottomRight.Points, seriesBottomLeft.Points);
            messageBottomRight = "Custom gist";
        }

        public void chartBuildDiscretization()
        {
            pointsClear();
            mainTitle.Text = "Discretization";
            //fill top left series 
            titleTopLeft.Text = "Aliasing";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Discretization(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = "";
            //fill top right series
            titleTopRight.Text = "Harmonic";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Discretization(seriesTopRight.Points, seriesTopRight.ChartArea);
            messageTopRight = "";
            //fill bottom left series
            titleBottomLeft.Text = "Harmonic + Spike + Shift";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Discretization(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            Plots.Spike(seriesBottomLeft.Points, 0.05, 500);
            Plots.Shift(seriesBottomLeft.Points, 1000);
            messageBottomLeft = "";
            //fill bottom right series
            titleBottomRight.Text = "Empty";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            messageBottomRight = "";
        }
        public void chartBuildDPF()
        {
            pointsClear();
            mainTitle.Text = "Fourier";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = Plots.CalculateBorder(0.002);
                area.AxisX.Minimum = 0;
            }
            //fill top left series 
            titleTopLeft.Text = "Graphic";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.PrepareDPF(seriesTopLeft.Points);
            messageTopLeft = "";
            //fill top right series
            titleTopRight.Text = "Frequency";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.DPF(seriesTopRight.Points, seriesTopRight.ChartArea);
            messageTopRight = "";
            //fill bottom left series
            titleBottomLeft.Text = "Real";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.DPF(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            messageBottomLeft = "";
            //fill bottom right series
            titleBottomRight.Text = "Image";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.DPF(seriesBottomRight.Points, seriesBottomRight.ChartArea);
            messageBottomRight = "";
        }
        public void chartBuildImpulseReact()
        {
            Plots.minX = 0;
            int M = 200;
            int N = 1000;
            //h(t)=A0*sin(2pif0*t)*e^(-at)
            pointsClear();
            mainTitle.Text = "Impulse Reaction";
            //fill top left series 
            titleTopLeft.Text = "Hearth beat";
            Plots.maxX = M;
            chart.ChartAreas[seriesTopLeft.ChartArea].AxisX.Maximum = Plots.maxX;
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Impulse(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            messageTopLeft = "";
            //fill bottom left series
            titleBottomLeft.Text = "Impulse";
            Plots.maxX = N;
            chart.ChartAreas[seriesBottomLeft.ChartArea].AxisX.Maximum = Plots.maxX;
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Impulse(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            messageBottomLeft = "";
            //fill top right series
            titleTopRight.Text = "Reaction";
            Plots.maxX = M + N - 1;
            chart.ChartAreas[seriesTopRight.ChartArea].AxisX.Maximum = Plots.maxX;
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.Impulse(seriesTopRight.Points, seriesTopRight.ChartArea);
            messageTopRight = "";
            //fill bottom right series
            titleBottomRight.Text = "";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            //Plots.DPF(seriesBottomRight.Points, seriesBottomRight.ChartArea);
            messageBottomRight = "";
        }

        //ANTISHIFT & ANTISPIKE
        //public void chartBuildTest()
        //{
        //pointsClear();
        //mainTitle.Text = "Test";
        //foreach (var area in chart.ChartAreas)
        //{
        //    area.AxisX.Maximum = Plots.maxX;
        //    area.AxisX.Minimum = 0;
        //}
        ////fill top left series 
        //titleTopLeft.Text = "Sin + Shift 100";
        //seriesTopLeft.ChartType = SeriesChartType.Spline;
        //seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
        //Plots.Test(seriesTopLeft.Points, seriesTopLeft.ChartArea);
        //messageTopLeft = "";
        ////fill top right series
        //titleTopRight.Text = "Sin + Spike";
        //seriesTopRight.ChartType = SeriesChartType.Spline;
        //seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
        //Plots.Test(seriesTopRight.Points, seriesTopRight.ChartArea);
        //messageTopRight = "";
        ////fill bottom left series
        //titleBottomLeft.Text = "AntiShift";
        //seriesBottomLeft.ChartType = SeriesChartType.Spline;
        //seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
        //Plots.Test(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
        //messageBottomLeft = "";
        ////fill bottom right series
        ////titleBottomRight.Text = "Image";
        ////seriesBottomRight.ChartType = SeriesChartType.Spline;
        ////seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
        ////Plots.DPF(seriesBottomRight.Points, seriesBottomRight.ChartArea);
        ////messageBottomRight = "";
        //}

        //ANTIRANDOM
        //public void chartBuildTest()
        //{
        //    pointsClear();
        //    Random r = new Random(51);
        //    int M = 2000;
        //    int f = 7;
        //    int A = 100;
        //    mainTitle.Text = "AntiRandom";
        //    foreach (var area in chart.ChartAreas)
        //    {
        //        area.AxisX.Maximum = Plots.maxX;
        //        area.AxisX.Minimum = 0;
        //    }
        //    //fill top left series 
        //    titleTopLeft.Text = "Signal";
        //    seriesTopLeft.ChartType = SeriesChartType.Spline;
        //    seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
        //    for (int i = 0; i < Plots.maxX; i++)
        //    {
        //        seriesTopLeft.Points.AddXY(i, Plots.SignalFunc(A, f, i));
        //    }
        //    messageTopLeft = "";
        //    //fill top right series
        //    titleTopRight.Text = "Signal-Random";
        //    seriesTopRight.ChartType = SeriesChartType.Spline;
        //    seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
        //    for (int i = 0; i < Plots.maxX; i++)
        //    {
        //        seriesTopRight.Points.AddXY(i, Plots.SignalFunc(A, f, i) + r.Next(-A*10, A*10));
        //    }
        //    for (int i = 0; i < M - 1; i++)
        //    {
        //        int j = 0;
        //        foreach (var point in seriesTopRight.Points)
        //        {
        //            point.YValues[0] += (Plots.SignalFunc(A, f, j) + r.Next(-A*10, A*10));
        //            j++;
        //        }
        //    }

        //    foreach (var point in seriesTopRight.Points)
        //    {
        //        point.YValues[0] = point.YValues[0] / M;
        //    }
        //    messageTopRight = "";
        //    //fill bottom left series
        //    titleBottomLeft.Text = "Signal+Random";
        //    seriesBottomLeft.ChartType = SeriesChartType.Spline;
        //    seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
        //    for (int i = 0; i < Plots.maxX; i++)
        //    {
        //        seriesBottomLeft.Points.AddXY(i, Plots.SignalFunc(100, 57, i) + r.Next(-100, 100));
        //    }
        //    messageBottomLeft = "";
        //    //fill bottom right series
        //    titleBottomRight.Text = "Random";
        //    seriesBottomRight.ChartType = SeriesChartType.Spline;
        //    seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
        //    for (int i = 0; i < Plots.maxX; i++)
        //    {
        //        seriesBottomRight.Points.AddXY(i, r.Next(-100, 100));
        //    }
        //    messageBottomRight = "";
        //    messageBottomRight += "СО (σ1)" + Statistics.CalcStandardDeviation(seriesBottomRight.Points);

        //}


        //Spikes Random
        public void chartBuildAntiTrend()
        {
            Random r = new Random(20);
            int A = 100;
            int W = 15;
            pointsClear();
            mainTitle.Text = "Anti Trend";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = Plots.maxX;
                area.AxisX.Minimum = 0;
            }
            //fill top left series 
            titleTopLeft.Text = "Trend";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            for (int i = 0; i < Plots.maxX; i++)
            {
                seriesTopLeft.Points.AddXY(i, 5 * i);
            }
            messageTopLeft = "";
            //fill top right series
            titleTopRight.Text = "AntiTrend";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            for (int i = 0; i < Plots.maxX; i++)
            {
                seriesTopRight.Points.AddXY(i, 5 * i + r.Next(-A, A));
            }
            double[] temp_array = seriesTopRight.Points.Select(y => y.YValues[0]).ToArray();
            for (int i = 0; i < Plots.maxX / W; i++)
            {
                double Xk = 0;
                for (int j = i * W; j < (i + 1) * W; j++)
                {
                    Xk += temp_array[j];
                }
                Xk = Xk / W;
                for (int j = i * W; j < (i + 1) * W; j++)
                {
                    temp_array[j] -= Xk;
                }
            }
            int k = 0;
            foreach (var point in seriesTopRight.Points)
            {
                point.YValues[0] = temp_array[k];
                k++;
            }
            messageTopRight = "";
            //fill bottom left series
            titleBottomLeft.Text = "Trend + Random";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            for (int i = 0; i < Plots.maxX; i++)
            {
                seriesBottomLeft.Points.AddXY(i, i + r.Next(-A, A));
            }
            messageBottomLeft = "";
            //fill bottom right series
            //titleBottomRight.Text = "Image";
            //seriesBottomRight.ChartType = SeriesChartType.Spline;
            //seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            //Plots.DPF(seriesBottomRight.Points, seriesBottomRight.ChartArea);
            //messageBottomRight = "";
        }
        static double fcut = 200;
        static int m = 32;
        static double dt = 0.002;
        static int cutter = 1;
        public void chartBuildFilterLDF_Test()
        {
            pointsClear();
            mainTitle.Text = "Filter";
            List<double> lpw = new List<double>();
            //прямоугольник
            double[] d = { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };
            double arg = 2 * fcut * dt;
            lpw.Add(arg);
            arg *= Math.PI;

            for (int i = 1; i <= m; i++)
            {
                lpw.Add(Math.Sin(arg * i) / (Math.PI * i));
            }
            //трапеция
            lpw[m] /= 2;

            //окно P310 (Поттера)
            double sumg = lpw[0];
            double sum = 0;
            for (int i = 1; i <= m; i++)
            {
                sum = d[0];
                arg = Math.PI * i / m;
                for (int k = 1; k <= 3; k++)
                    sum += 2 * d[k] * Math.Cos(arg * k);
                lpw[i] *= sum;
                sumg += 2 * lpw[i];
            }
            //нормировка
            for (int i = 0; i <= m; i++)
                lpw[i] /= sumg;
            //зеркально отразить график, сдвинуть, чтобы был от 0 до 2m+1 (сейчас он от 0 до m+1)

            //fill top left series 
            titleTopLeft.Text = "m(" + m + ")+1";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = lpw.Count;
                area.AxisX.Minimum = 0;
            }
            for (int i = 0; i < lpw.Count; i++)
            {
                seriesTopLeft.Points.AddXY(i, lpw[i]);
            }
            messageTopLeft = "";
            //fill bottom left series 
            titleBottomLeft.Text = "2m(" + 2 * m + ")+1";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = lpw.Count * 2 + 1;
                area.AxisX.Minimum = 0;
            }
            List<double> total_lpw = new List<double>();
            lpw.Reverse();
            total_lpw.AddRange(lpw);

            total_lpw.RemoveAt(total_lpw.Count - 1);
            lpw.Reverse();
            total_lpw.AddRange(lpw);
            for (int i = 0; i < total_lpw.Count; i++)
            {
                seriesBottomLeft.Points.AddXY(i, total_lpw[i]);
            }
            messageBottomLeft = "";
            //fill top right series
            titleTopRight.Text = "DPF";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = total_lpw.Count;
            Plots.PrepareDPF_Filter(seriesBottomLeft.Points);
            chartAreaTopRight.AxisX.Maximum = Plots.CalculateBorder(dt);
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                seriesTopRight.Points.AddXY(2 * i * Plots.CalculateBorder(dt) / Plots.FourierArr.Length, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageTopRight = "";
            //fill bottom right series
            titleBottomRight.Text = "DPF";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                //seriesTopRight.Points.AddXY(i, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageTopRight = "";
        }

        public void chartBuildFilter()
        {
            Parser.Do();
            pointsClear();
            mainTitle.Text = "Filter LPF";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = Parser.parser.Count;
                area.AxisX.Minimum = 0;
            }
            //fill top left series 
            titleTopLeft.Text = "Parse";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = Parser.parser.Count;
            Plots.AddFilter(seriesTopLeft.Points, seriesTopLeft.ChartArea, fcut, m, dt);
            messageTopLeft = "";

            ////fill top right series
            //titleTopRight.Text = "LPF";
            //seriesTopRight.ChartType = SeriesChartType.Spline;
            //seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            //Plots.minX = 0;
            //Plots.maxX = Parser.parser.Count;
            //fcut = 200;
            //Plots.AddFilter(seriesTopRight.Points, seriesTopRight.ChartArea, fcut, m, dt);
            //messageTopRight = "";

            //fill bottom left series
            titleBottomLeft.Text = "BPF";
            seriesBottomLeft.ChartType = SeriesChartType.FastLine;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = Parser.parser.Count;
            fcut = 190;
            Plots.AddFilter(seriesBottomLeft.Points, seriesBottomRight.ChartArea, fcut, m, dt);
            messageBottomLeft = "";

            ////fill bottom right series
            //titleBottomRight.Text = "BPF";
            //seriesBottomRight.ChartType = SeriesChartType.Spline;
            //seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            //Plots.minX = 0;
            //Plots.maxX = Parser.parser.Count;
            //fcut = 200;
            //Plots.AddFilter(seriesBottomRight.Points, seriesBottomRight.ChartArea, fcut, m, dt);
            //messageBottomRight = "";

            //fill top right series
            titleTopRight.Text = "DPF Input";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = Parser.parser.Count;
            Plots.PrepareDPF_Filter(seriesTopLeft.Points);
            //Plots.DPF(seriesTopRight.Points, seriesTopRight.ChartArea);
            chartAreaTopRight.AxisX.Maximum = Plots.CalculateBorder(dt);
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                seriesTopRight.Points.AddXY(2 * i * Plots.CalculateBorder(dt) / Plots.FourierArr.Length, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageTopRight = "";

            //fill bottom right series
            titleBottomRight.Text = "DPF Output";
            seriesTopRight.ChartType = SeriesChartType.FastLine;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = Parser.parser.Count;
            Plots.PrepareDPF_Filter(seriesBottomLeft.Points);
            //Plots.DPF(seriesBottomRight.Points, seriesTopRight.ChartArea);
            chartAreaBottomRight.AxisX.Maximum = Plots.CalculateBorder(dt);
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                seriesBottomRight.Points.AddXY(2 * i * Plots.CalculateBorder(dt) / Plots.FourierArr.Length, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageBottomRight = "";
        }


        public void chartBuildVoiceFilter()
        {
            int rate = 0;
            NAudio.Wave.WaveFormat format = null;
            var data = AudioFilter.readWav("input_prep.wav", out rate, out format);
            dt = 1.0 / rate;
            fcut = 1800;
            m = 128;
            pointsClear();
            mainTitle.Text = "Filter Voice";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = data.Length / cutter;
                area.AxisX.Minimum = 0;
            }
            foreach (var series in chart.Series)
            {
                series.Points.SuspendUpdates();
            }
            //fill top left series 
            titleTopLeft.Text = "Input";
            seriesTopLeft.ChartType = SeriesChartType.FastLine;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopLeft.Points.AddXY(i, data[i]);
            }
            messageTopLeft = "";

            //fill top right series
            titleTopRight.Text = "BPF";
            seriesTopRight.ChartType = SeriesChartType.FastLine;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            List<double> filter = Plots.BPF_Filter(400, 900, m, dt);
            float[] data_out = new float[data.Length + 2 * m + 1];
            for (int k = Plots.minX; k < Plots.maxX; k++)
            {
                double y = 0;
                for (int l = Plots.minX; l < data.Length + 2 * m + 1; l++)
                {
                    if (k >= l && (k - l) < filter.Count)
                    {
                        y += filter[k - l] * data[l];
                    }
                }
                seriesTopRight.Points.AddXY(k, y);
                data_out[k] = (float)y;

            }
            messageTopRight = "";

            //cut first m and last m+1
            float[] result = new float[data.Length];
            for (int i = m; i < data.Length + m; i++)
            {
                result[i - m] = data_out[i];
            }


            //fill bottom left series
            titleBottomLeft.Text = "DPF Input";
            seriesBottomLeft.ChartType = SeriesChartType.FastLine;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = (int)Plots.CalculateBorder(dt);
            Plots.PrepareDPF_Filter(seriesTopLeft.Points);
            chartAreaBottomLeft.AxisX.Maximum = Plots.CalculateBorder(dt);
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                seriesBottomLeft.Points.AddXY(2 * i * Plots.CalculateBorder(dt) / Plots.FourierArr.Length, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageBottomLeft = "";

            //fill bottom right series
            titleBottomRight.Text = "DPF Output";
            seriesBottomRight.ChartType = SeriesChartType.FastLine;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = (int)Plots.CalculateBorder(dt);
            Plots.PrepareDPF_Filter(seriesTopRight.Points);
            chartAreaBottomRight.AxisX.Maximum = Plots.CalculateBorder(dt);
            for (int i = 0; i < Plots.FourierArr.Length; i++)
            {
                seriesBottomRight.Points.AddXY(2 * i * Plots.CalculateBorder(dt) / Plots.FourierArr.Length, Plots.FourierArr[i].C * (2 * m + 1));
            }
            messageBottomRight = "";

            foreach (var series in chart.Series)
            {
                series.Points.ResumeUpdates();
            }

            AudioFilter.writeWav("outputBPF_.wav", format, result);
        }

        public void Kurs_Lukoil()
        {
            double[] data = Parser.GetData("DataSheet.txt");
            pointsClear();
            mainTitle.Text = "Lukoil";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = data.Length;
                area.AxisX.Minimum = 0;
            }
            foreach (var series in chart.Series)
            {
                series.Points.SuspendUpdates();
            }
            //fill top left series 
            titleTopLeft.Text = "Input";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopLeft.Points.AddXY(i, data[i]);
            }
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points);

            //fill top right series
            titleTopRight.Text = "AntiTrend Input";
            seriesTopRight.ChartType = SeriesChartType.FastLine;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            double[] output = Plots.Antitrend(data);
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopRight.Points.AddXY(i, output[i]);
            }
            messageTopRight = Statistics.GetStatistics(seriesTopRight.Points);

            //fill bottom left series
            titleBottomLeft.Text = "AntiSpike Input";
            seriesBottomLeft.ChartType = SeriesChartType.FastLine;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            output = Plots.AntiSpike(seriesTopRight.Points, 0.75);
            for (int i = 0; i < output.Length; i++)
            {
                seriesBottomLeft.Points.AddXY(i, output[i]);
            }
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points);

            //fill bottom right series
            titleBottomRight.Text = "Auto Correlation";
            seriesBottomRight.ChartType = SeriesChartType.FastLine;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesBottomLeft.Points, seriesBottomLeft.Points);
            messageBottomRight = "";
        }

        public void Kurs_Model()
        {

            //x(t) = c * exp((µ – σ2 / 2) * t + σ * r(t))

            //где c – положительная константа > 1,  
            //r(t) - случайный процесс например в интервале[0, c], 
            //µ -среднее значение r(t), σ – стандартное отклонение r(t).
            //double[] data = new double[5000];
            double[] data = Parser.GetData("DataSheet.txt");
            pointsClear();
            double c = 0.015;
            Random r = new Random(5);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = r.NextDouble() * c;
            }
            double avg = Statistics.CalcAVG(data);
            double sigma = Math.Sqrt(Statistics.CalcDispersion(data));
            mainTitle.Text = "Model";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = data.Length;
                area.AxisX.Minimum = 0;
            }
            foreach (var series in chart.Series)
            {
                series.Points.SuspendUpdates();
            }
            //fill top left series 
            titleTopLeft.Text = "Input Random [0, " + c + "]";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = data.Length;
            //x(t) = c * exp((avg – sigma^2 / 2) * i + sigma * data(i))
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopLeft.Points.AddXY(i, c * Math.Pow(Math.E, ((avg - Math.Pow(sigma, 2) / 2) * i + sigma * data[i])));
            }
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points);
            data = seriesTopLeft.Points.Select(y => y.YValues[0]).ToArray();
            //fill top right series
            titleTopRight.Text = "AntiTrend Input";
            seriesTopRight.ChartType = SeriesChartType.FastLine;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            double[] output = Plots.Antitrend(data);
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopRight.Points.AddXY(i, output[i]);
            }
            messageTopRight = Statistics.GetStatistics(seriesTopRight.Points);

            //fill bottom left series
            titleBottomLeft.Text = "AntiSpike Input";
            seriesBottomLeft.ChartType = SeriesChartType.FastLine;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            output = Plots.AntiSpike(seriesTopRight.Points, 4);
            for (int i = 0; i < output.Length; i++)
            {
                seriesBottomLeft.Points.AddXY(i, output[i]);
            }
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points);

            //fill bottom right series
            titleBottomRight.Text = "Auto Correlation";
            seriesBottomRight.ChartType = SeriesChartType.FastLine;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesTopRight.Points, seriesTopRight.Points);
            messageBottomRight = "";
        }
        public void Kurs_Model_My()
        {
            double[] data_real = Parser.GetData("DataSheet.txt");
            double[] data = new double[data_real.Length];
            for (int i = 0; i < data_real.Length; i++)
                data[i] = data_real[i];
            pointsClear();
            Random r = new Random(555555);
            data[0] = 0;
            double rand = 0;
            for (int i = 1; i < data.Length; i++)
            {
                rand = r.NextDouble();
                if (rand > 0.5)
                    data[i] = data[i - 1] + r.NextDouble();
                else data[i] = data[i - 1] - r.NextDouble();
            }
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = -data[i];
            }
            //replce first part with another randomization
            for (int i = 0; i < 400; i++)
            {
                rand = r.NextDouble();
                if (rand > 0.8)
                    data[i] = data[401] + r.NextDouble();
                else if (rand > 0.7) data[i] = data[401] - r.NextDouble();
                else data[i] = data[i - 1];
            }

            //scale model to real
            double scale = 0;
            for (int i = 0; i < data.Length; i++)
            {
                scale += data_real[i] / data[i];
            }
            scale = scale / data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                data[i] *= scale;
            }
            double avg = Statistics.CalcAVG(data);
            double sigma = Math.Sqrt(Statistics.CalcDispersion(data));
            mainTitle.Text = "Model";
            foreach (var area in chart.ChartAreas)
            {
                area.AxisX.Maximum = data.Length;
                area.AxisX.Minimum = 0;
            }
            foreach (var series in chart.Series)
            {
                series.Points.SuspendUpdates();
            }
            //fill top left series 
            titleTopLeft.Text = "Input Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            seriesTopLeft.BorderDashStyle = ChartDashStyle.Solid;
            Plots.minX = 0;
            Plots.maxX = data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopLeft.Points.AddXY(i, data[i]);
            }
            messageTopLeft = Statistics.GetStatistics(seriesTopLeft.Points);
            data = seriesTopLeft.Points.Select(y => y.YValues[0]).ToArray();
            //fill top right series
            titleTopRight.Text = "AntiTrend Input";
            seriesTopRight.ChartType = SeriesChartType.FastLine;
            seriesTopRight.BorderDashStyle = ChartDashStyle.Solid;
            double[] output = Plots.Antitrend(data);
            for (int i = 0; i < data.Length; i++)
            {
                seriesTopRight.Points.AddXY(i, output[i]);
            }
            messageTopRight = Statistics.GetStatistics(seriesTopRight.Points);

            //fill bottom left series
            titleBottomLeft.Text = "AntiSpike Input";
            seriesBottomLeft.ChartType = SeriesChartType.FastLine;
            seriesBottomLeft.BorderDashStyle = ChartDashStyle.Solid;
            output = Plots.AntiSpike(seriesTopRight.Points, 4);
            for (int i = 0; i < output.Length; i++)
            {
                seriesBottomLeft.Points.AddXY(i, output[i]);
            }
            messageBottomLeft = Statistics.GetStatistics(seriesBottomLeft.Points);

            //fill bottom right series
            titleBottomRight.Text = "Auto Correlation";
            seriesBottomRight.ChartType = SeriesChartType.FastLine;
            seriesBottomRight.BorderDashStyle = ChartDashStyle.Solid;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesTopRight.Points, seriesTopRight.Points);
            messageBottomRight = "";
        }
    }
}
