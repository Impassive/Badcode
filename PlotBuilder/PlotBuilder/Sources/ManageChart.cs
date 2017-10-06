﻿using System;
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

        public ManageChart(GroupBox gbox)
        {
            chartInit();
            gbox.Controls.Add(chart);
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
        }

        private void pointsClear()
        {
            foreach(var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        public void chartBuildTrends()
        {
            pointsClear();
            mainTitle.Text = "Trends";
            //fill top left series
            titleTopLeft.Text = "y=ax+b";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            Plots.Trends(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            //fill top right series
            titleTopRight.Text = "y=(-a)x+b";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            Plots.Trends(seriesTopRight.Points, seriesTopRight.ChartArea);
            //fill bottom left series
            titleBottomLeft.Text = "y=be^(-ax)";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            Plots.Trends(seriesBottomLeft.Points, seriesBottomLeft.ChartArea, 1, 1);
            //fill bottom right series
            titleBottomRight.Text = "y=be^(ax)";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            Plots.Trends(seriesBottomRight.Points, seriesBottomRight.ChartArea, 1, 1);
        }
        public void chartBuildRandomAndAutoCorrelation()
        {
            pointsClear();
            mainTitle.Text = "Random & Auto Correlation";
            //fill top left series 
            titleTopLeft.Text = "Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            Plots.Random(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            //fill top right series - Auto correlation for top left
            titleTopRight.Text = "Auto Correlation";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            Plots.AutoCrossCorrelation(seriesTopRight.Points, seriesTopLeft.Points, seriesTopLeft.Points);
            //fill bottom left series
            titleBottomLeft.Text = "Custom";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            Plots.Random(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            //fill bottom right series - Auto correlation for bottom left
            titleBottomRight.Text = "Auto Correlation";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesBottomLeft.Points, seriesBottomLeft.Points);
        }
        public void chartBuildRandomAndCrossCorrelation()
        {
            pointsClear();
            mainTitle.Text = "Random & Cross Correlation";
            //fill top left series 
            titleTopLeft.Text = "Random";
            seriesTopLeft.ChartType = SeriesChartType.Spline;
            Plots.Random(seriesTopLeft.Points, seriesTopLeft.ChartArea);
            //fill bottom left series
            titleBottomLeft.Text = "Custom";
            seriesBottomLeft.ChartType = SeriesChartType.Spline;
            Plots.Random(seriesBottomLeft.Points, seriesBottomLeft.ChartArea);
            //fill top right series - Auto correlation for top left
            titleTopRight.Text = "Random-custom Cross Correlation";
            seriesTopRight.ChartType = SeriesChartType.Spline;
            Plots.AutoCrossCorrelation(seriesTopRight.Points, seriesTopLeft.Points, seriesBottomLeft.Points);
            //fill bottom right series - Auto correlation for bottom left
            titleBottomRight.Text = "Custom-random Cross Correlation";
            seriesBottomRight.ChartType = SeriesChartType.Spline;
            Plots.AutoCrossCorrelation(seriesBottomRight.Points, seriesBottomLeft.Points, seriesTopLeft.Points);
        }
    }
}
