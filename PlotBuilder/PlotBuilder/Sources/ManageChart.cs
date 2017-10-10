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
                chartAreas.AxisX.IsMarginVisible = false;
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

        private void pointsClear()
        {
            foreach (var series in chart.Series)
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

        public void chartMaximazed(bool maximazed = true)
        {
            if (maximazed)
            {
                foreach (var series in chart.Series)
                {
                    series.BorderWidth = 4;
                }
            }
            else
            {
                foreach (var series in chart.Series)
                {
                    series.BorderWidth = 1;
                }
            }
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
    }
}
