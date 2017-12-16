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

        private void toolStripMaxXtxtBox_Click(object sender, EventArgs e)
        {
            toolStripMaxXtxtBox.Text = "";
        }

        private void toolStripMinYtxtBox_Click(object sender, EventArgs e)
        {
            toolStripMinYtxtBox.Text = "";
        }

        private void toolStripMaxYtxtBox_Click(object sender, EventArgs e)
        {
            toolStripMaxYtxtBox.Text = "";
        }

        private void toolStripMaxXtxtBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Plots.maxX = Int32.Parse(toolStripMaxXtxtBox.Text);
            }
            catch { }
            toolStripMaxXtxtBox.Text = "max X: " + Plots.maxX.ToString();
            this.Focus();
        }

        private void toolStripMinYtxtBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Plots.minY = Int32.Parse(toolStripMinYtxtBox.Text);
            }
            catch { }
            toolStripMinYtxtBox.Text = "min Y: " + Plots.minY.ToString();
            this.Focus();
        }

        private void toolStripMaxYtxtBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Plots.maxY = Int32.Parse(toolStripMaxYtxtBox.Text);
            }
            catch { }
            toolStripMaxYtxtBox.Text = "max Y: " + Plots.maxY.ToString();
            this.Focus();
        }

        private void gistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildRandomAndGist();
        }

        private void discrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildDiscretization();
        }

        private void fourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildDPF();
        }

        private void impulseReactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildImpulseReact();
        }
        private void lDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildFilter();
        }

        private void parseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parser.Do();
        }

        private void antiTrendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildAntiTrend();
        }

        private void testLPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildFilterLDF_Test();
        }

        private void voiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.chartBuildVoiceFilter();
        }


        private void lukoilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.Kurs_Lukoil();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart.Kurs_Model();
        }
    }
}
