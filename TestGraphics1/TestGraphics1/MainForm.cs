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
        public static int N = 0;
        public static Series series;
        public static Title title;
        public static Font font;

        public MainForm()
        {
            N = 400;
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
            
        }

        public void update_analysis()
        {
            if (analytics_box.Visible == true)
            {
                middle_label_fill();
                left_label_fill();
                right_label_fill();
            }
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Chart_plots.chart_graph_random(Int32.Parse(toolStripTextBox1.Text), true);
                }
                catch
                {
                    toolStripTextBox1.Text = "0";
                }
            }
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
            analytics_label_left.Text += "СЗ: " + Math.Round(Analysis.Calculate_avg(series.Points), 2) + "\n\t";
            analytics_label_left.Text += "СК: " + Math.Round(Analysis.Calculate_rms(series.Points), 2) + "\n\t";
            analytics_label_left.Text += "Дисперсия: " + Math.Round(Analysis.Calculate_dispersion(series.Points,2), 2) + "\n\t";
            analytics_label_left.Text += "СКО: " + Math.Round(Analysis.Calculate_standard_deviation(series.Points), 2) + "\n\t";
        }

        private void middle_label_fill()
        {
            analitics_label_middle.Text = "";
            analitics_label_middle.Text += "СО (σ): " + Math.Round(Analysis.Calculate_avg_deviation(series.Points), 2) + "\n\t";
            analitics_label_middle.Text += "3-ий момент: " + Math.Round(Analysis.Calculate_dispersion(series.Points, 3), 2) + "\n\t";
            analitics_label_middle.Text += "4-ый момент: " + Math.Round(Analysis.Calculate_dispersion(series.Points, 4), 2) + "\n\t";
        }

        private void right_label_fill()
        {
            analitics_label_right.Text = "";
            analitics_label_right.Text += "Асимметрия: " + Math.Round(Analysis.Calculate_asymmetry(series.Points), 2) + "\n\t";
            analitics_label_right.Text += "Эксцесс: " + Math.Round(Analysis.Calculate_kurtosis(series.Points), 2) + "\n\t";
        }
        private void hidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Remove(analytics_box);
            analytics_box.Visible = false;
        }

        private void yaxbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_1(1, 1);
            chart.Update();
            update_analysis();
        }

        private void ybeaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chart.Series.Count > 0)
            {
                chart_clear();
            }
            Chart_plots.chart_graph_2(1, 1);
            chart.Update();
            update_analysis();
        }
    }
}
