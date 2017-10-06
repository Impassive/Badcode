using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlotBuilder.Sources;
using System.Threading;

namespace PlotBuilder
{
    public partial class MainForm : Form
    {
        ManageChart chart;
        public MainForm()
        {
            InitializeComponent();
            chart = new ManageChart(this.chartBox);
        }

        private void trendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildTrends();
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildRandomAndAutoCorrelation();
        }

        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildRandomAndCrossCorrelation();
        }

        private void toolStripMinXtxtBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Plots.minX = Int32.Parse(toolStripMinXtxtBox.Text);
            }
            catch { }
            toolStripMinXtxtBox.Text = "min X: " + Plots.minX.ToString();
            this.Focus();
        }

        private void toolStripMinXtxtBox_Click(object sender, EventArgs e)
        {
            toolStripMinXtxtBox.Text = "";
        }
    }
}
