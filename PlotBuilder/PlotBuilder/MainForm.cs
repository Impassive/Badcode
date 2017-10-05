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
        public MainForm()
        {
            InitializeComponent();
            ManageChart chart = new ManageChart(this.chartBox);
        }
        //public static void addControl(Control control)
        //{
        //    Controls.Add(control);
        //}
        //public static void removeControl(Control control)
        //{
        //    Controls.Remove(control);
        //}
    }
}
