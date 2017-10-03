using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestGraphics
{
    public partial class MainForm : Form
    {
        private List<ToolStripMenuItem> menus = new List<ToolStripMenuItem>();
        public static Series series;
        public static Title title;
        public static Font font;
        public static Series temp_series;
        public static int left_X = 0;
        public static int right_X = 40;
        public static int min_Y = 0;
        public static int max_Y = 1;
        public static bool stat = false;
        public static bool cor = false;
        public static int stat_delimiter = 10;

        public MainForm()
        {
            InitializeComponent();
            chart_init();
        }

        public void chart_init()
        {
            chart.Parent = graphic_box;
            analytics_box.Enabled = false;
            analytics_box.Visible = false;
            analytics_box.Dock = DockStyle.Bottom;
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea("functions"));
            font = new Font("MyFont", 20);
            title = new Title("Hello", Docking.Top, font, Color.Black);
            series = new Series("series1");
            temp_series = new Series("series2");
            series.ChartType = SeriesChartType.Spline;
            series.ChartArea = "functions";
            chart.Series.Add(series);
            chart.Titles.Add(title);
        }


        public void chart_clear()
        {
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
            series.ChartType = SeriesChartType.Spline;
        }

        public void update_analysis()
        {
            if (analytics_box.Visible)
            {
                if (!cor)
                {
                    middle_label_fill();
                    left_label_fill();
                    right_label_fill();
                    stat = false;
                }
                else
                {
                    show_correlation_analytics();
                    cor = false;
                }
            }
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stat = true;
            cor = false;
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_random(DateTime.Now.Millisecond, false);
            chart.Update();
            update_analysis();
        }

        private void customRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stat = true;
            cor = false;
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_random(DateTime.Now.Millisecond, true);
            chart.Update();
            update_analysis();
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            cor = false;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (chart.Series.Count > 0)
                    {
                        chart_clear();
                    }
                    Chart_plots.chart_graph_random(Int32.Parse(toolStripTextBox1.Text), true);
                }
                catch
                {
                    toolStripTextBox1.Text = "0";
                }
            }
            stat = true;
            chart.Update();
            update_analysis();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Add(analytics_box);
            analytics_box.Visible = true;
            analytics_box.Enabled = true;
            update_analysis();
        }

        private void left_label_fill()
        {
            analytics_label_left.Text = "";
            analytics_label_left.Text += "СЗ: " + Math.Round(Analysis.Calculate_avg(series.Points), 5) + "\n\t";
            analytics_label_left.Text += "СК: " + Math.Round(Analysis.Calculate_rms(series.Points), 5) + "\n\t";
            analytics_label_left.Text += "Дисперсия: " + Math.Round(Analysis.Calculate_dispersion(series.Points, 2), 5) + "\n\t";
            analytics_label_left.Text += "СКО: " + Math.Round(Analysis.Calculate_standard_deviation(series.Points), 5) + "\n\t";
        }

        private void middle_label_fill()
        {
            analytics_label_middle.Text = "";
            analytics_label_middle.Text += "|  СО (σ): " + Math.Round(Analysis.Calculate_avg_deviation(series.Points), 2) + "\n\t";
            analytics_label_middle.Text += "|  3-ий момент: " + Math.Round(Analysis.Calculate_dispersion(series.Points, 3), 2) + "\n\t";
            analytics_label_middle.Text += "|  4-ый момент: " + Math.Round(Analysis.Calculate_dispersion(series.Points, 4), 2) + "\n\t";
            analytics_label_middle.Text += "|  \n\t";
        }

        private void right_label_fill()
        {
            analytics_label_right.Text = "";
            analytics_label_right.Text += "|  Асимметрия: " + Math.Round(Analysis.Calculate_asymmetry(series.Points), 2) + "\n\t";
            analytics_label_right.Text += "|  Эксцесс: " + Math.Round(Analysis.Calculate_kurtosis(series.Points), 2) + "\n\t";
            if (stat)
            {
                analytics_label_right.Text += "|  Стационарность: " +Analysis.Calculate_stationarity(series.Points) + "\n\t";
            }
            analytics_label_right.Text += "|  \n\t";
        }

        private void hidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Remove(analytics_box);
            analytics_box.Visible = false;
            cor = false;
            stat = false;
        }

        private void yaxbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cor = false;
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_1(1, 0);
            chart.Update();
            update_analysis();
        }

        private void ybeaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cor = false;
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_2(1, 1);
            chart.Update();
            update_analysis();
        }

        private void gistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cor = false;
            stat = false;
            if (series.ChartType != SeriesChartType.Column)
            {
                try
                {
                    int[] gist = Analysis.prepare_gist_data(series.Points, 10);
                    if (chart.Series.Count > 0)
                    { chart_clear(); }
                    Chart_plots.prepare_gist(gist);
                }
                catch
                {
                    title.Text = "No Data";
                }
                series.ChartType = SeriesChartType.Column;
                chart.Update();
                Controls.Remove(analytics_box);
                analytics_box.Visible = false;
            }
            else
            {
                chart_clear();
                title.Text = "Gist of gist, sure?";
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Text = "";
        }

        private void toolStripTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            cor = false;
            stat = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (series.ChartType != SeriesChartType.Column)
                {
                    try
                    {
                        int[] gist = Analysis.prepare_gist_data(series.Points, Int32.Parse(toolStripTextBox2.Text));
                        if (chart.Series.Count > 0)
                        { chart_clear(); }
                        Chart_plots.prepare_gist(gist);
                    }
                    catch
                    {
                        toolStripTextBox2.Text = "Enter bars num";
                        title.Text = "No Data";
                    }
                    series.ChartType = SeriesChartType.Column;
                    chart.Update();
                    Controls.Remove(analytics_box);
                    analytics_box.Visible = false;
                }
                else
                {
                    chart_clear();
                    title.Text = "Gist of gist, sure?";
                }
            }

        }

        private void correlationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cor = true;
            temp_series.Color = Color.Red;
            if (chart.Series.Count > 0)
            {
                chart_clear();
                chart.Series.Remove(temp_series);
            }
            temp_series.ChartType = SeriesChartType.Spline;
            temp_series.ChartArea = "functions";
            chart.Series.Add(temp_series);
            Chart_plots.chart_dual(DateTime.Now.Millisecond);
            chart.Update();
            show_correlation_analytics();
        }
        private void show_correlation_analytics()
        {
            int lag = 10;
            Controls.Add(analytics_box);
            analytics_box.Visible = true;
            analytics_box.Enabled = true;
            analytics_label_middle.Text = "";
            analytics_label_right.Text = "";
            analytics_label_left.Text = "";
            analytics_label_left.Text += "Auto Correlation for custom random: " + Math.Round(Analysis.Calculate_cross_correlation(temp_series.Points, temp_series.Points, lag), 2) + "\n\t";
            analytics_label_left.Text += "Auto Correlation for lib random: " + Math.Round(Analysis.Calculate_cross_correlation(series.Points, series.Points, lag), 2) + "\n\t";
            analytics_label_left.Text += "Cross Correlation cutom-lib: " + Math.Round(Analysis.Calculate_cross_correlation(series.Points, temp_series.Points, lag), 2) + "\n\t";
            analytics_label_left.Text += "Cross Correlation lib-custom: " + Math.Round(Analysis.Calculate_cross_correlation(temp_series.Points, series.Points, lag), 2) + "\n\t";
        }

        private void toolStripleft_Click(object sender, EventArgs e)
        {
            toolStripleft.Text = "";
        }

        private void toolStripright_Click(object sender, EventArgs e)
        {
            toolStripright.Text = "";
        }

        private void toolStripleft_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    left_X = Int32.Parse(toolStripleft.Text);
                    toolStripleft.Text = "left: " + left_X;
                }
                catch
                {
                    left_X = 0;
                    toolStripleft.Text = "left: " + left_X;
                }
            }
        }

        private void toolStripright_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    right_X = Int32.Parse(toolStripright.Text);
                    toolStripright.Text = "right: " + right_X;
                }
                catch
                {
                    right_X = 40;
                    toolStripright.Text = "right: " + right_X;
                }
            }
        }

        private void toolStripmin_Click(object sender, EventArgs e)
        {
            toolStripmin.Text = "";
        }

        private void toolStripmax_Click(object sender, EventArgs e)
        {
            toolStripmax.Text = "";
        }

        private void toolStripmin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    min_Y = Int32.Parse(toolStripmin.Text);
                    toolStripmin.Text = "min: " + min_Y;
                }
                catch
                {
                    min_Y = 0;
                    toolStripmin.Text = "min: " + min_Y;
                }
            }
        }

        private void toolStripmax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    max_Y = Int32.Parse(toolStripmax.Text);
                    toolStripmax.Text = "max: " + max_Y;
                }
                catch
                {
                    max_Y = 1;
                    toolStripmax.Text = "max: " + max_Y;
                }
            }
        }
    }
}
