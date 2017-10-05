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
    }
}
