namespace TestGraphics
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yaxbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ybeaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.func6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.analyticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gistToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.hidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphic_box = new System.Windows.Forms.GroupBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.analytics_label_right = new System.Windows.Forms.Label();
            this.analytics_box = new System.Windows.Forms.GroupBox();
            this.analytics_label_middle = new System.Windows.Forms.Label();
            this.analytics_label_left = new System.Windows.Forms.Label();
            this.correlationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.graphic_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.analytics_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestToolStripMenuItem,
            this.func6ToolStripMenuItem,
            this.analyticsToolStripMenuItem,
            this.correlationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(837, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TestToolStripMenuItem
            // 
            this.TestToolStripMenuItem.CheckOnClick = true;
            this.TestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yaxbToolStripMenuItem,
            this.ybeaxToolStripMenuItem});
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.TestToolStripMenuItem.Text = "Test";
            // 
            // yaxbToolStripMenuItem
            // 
            this.yaxbToolStripMenuItem.Name = "yaxbToolStripMenuItem";
            this.yaxbToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.yaxbToolStripMenuItem.Text = "y=ax+b";
            this.yaxbToolStripMenuItem.Click += new System.EventHandler(this.yaxbToolStripMenuItem_Click);
            // 
            // ybeaxToolStripMenuItem
            // 
            this.ybeaxToolStripMenuItem.Name = "ybeaxToolStripMenuItem";
            this.ybeaxToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.ybeaxToolStripMenuItem.Text = "y=be^(-ax)";
            this.ybeaxToolStripMenuItem.Click += new System.EventHandler(this.ybeaxToolStripMenuItem_Click);
            // 
            // func6ToolStripMenuItem
            // 
            this.func6ToolStripMenuItem.CheckOnClick = true;
            this.func6ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.customRandomToolStripMenuItem});
            this.func6ToolStripMenuItem.Name = "func6ToolStripMenuItem";
            this.func6ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.func6ToolStripMenuItem.Text = "Random";
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.randomToolStripMenuItem.Text = "Random ";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // customRandomToolStripMenuItem
            // 
            this.customRandomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.customRandomToolStripMenuItem.Name = "customRandomToolStripMenuItem";
            this.customRandomToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.customRandomToolStripMenuItem.Text = "Custom random";
            this.customRandomToolStripMenuItem.Click += new System.EventHandler(this.customRandomToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.Text = "Enter interval";
            this.toolStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyUp);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // analyticsToolStripMenuItem
            // 
            this.analyticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateToolStripMenuItem,
            this.gistToolStripMenuItem1,
            this.hidToolStripMenuItem});
            this.analyticsToolStripMenuItem.Name = "analyticsToolStripMenuItem";
            this.analyticsToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.analyticsToolStripMenuItem.Text = "Analytics";
            // 
            // calculateToolStripMenuItem
            // 
            this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
            this.calculateToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.calculateToolStripMenuItem.Text = "Calculate";
            this.calculateToolStripMenuItem.Click += new System.EventHandler(this.calculateToolStripMenuItem_Click);
            // 
            // gistToolStripMenuItem1
            // 
            this.gistToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.gistToolStripMenuItem1.Name = "gistToolStripMenuItem1";
            this.gistToolStripMenuItem1.Size = new System.Drawing.Size(145, 26);
            this.gistToolStripMenuItem1.Text = "Gist";
            this.gistToolStripMenuItem1.Click += new System.EventHandler(this.gistToolStripMenuItem1_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.Text = "Enter bars num";
            this.toolStripTextBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox2_KeyUp);
            this.toolStripTextBox2.Click += new System.EventHandler(this.toolStripTextBox2_Click);
            // 
            // hidToolStripMenuItem
            // 
            this.hidToolStripMenuItem.Name = "hidToolStripMenuItem";
            this.hidToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.hidToolStripMenuItem.Text = "Hide";
            this.hidToolStripMenuItem.Click += new System.EventHandler(this.hidToolStripMenuItem_Click);
            // 
            // graphic_box
            // 
            this.graphic_box.AutoSize = true;
            this.graphic_box.Controls.Add(this.chart);
            this.graphic_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphic_box.Location = new System.Drawing.Point(0, 28);
            this.graphic_box.Name = "graphic_box";
            this.graphic_box.Size = new System.Drawing.Size(837, 467);
            this.graphic_box.TabIndex = 2;
            this.graphic_box.TabStop = false;
            this.graphic_box.Text = "Graphic";
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(218, 32);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(300, 300);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // analytics_label_right
            // 
            this.analytics_label_right.AutoSize = true;
            this.analytics_label_right.Dock = System.Windows.Forms.DockStyle.Left;
            this.analytics_label_right.Location = new System.Drawing.Point(180, 18);
            this.analytics_label_right.Name = "analytics_label_right";
            this.analytics_label_right.Size = new System.Drawing.Size(46, 17);
            this.analytics_label_right.TabIndex = 1;
            this.analytics_label_right.Text = "";
            // 
            // analytics_box
            // 
            this.analytics_box.Controls.Add(this.analytics_label_right);
            this.analytics_box.Controls.Add(this.analytics_label_middle);
            this.analytics_box.Controls.Add(this.analytics_label_left);
            this.analytics_box.Location = new System.Drawing.Point(12, 413);
            this.analytics_box.Name = "analytics_box";
            this.analytics_box.Size = new System.Drawing.Size(811, 81);
            this.analytics_box.TabIndex = 3;
            this.analytics_box.TabStop = false;
            this.analytics_box.Text = "Analytics";
            // 
            // analytics_label_middle
            // 
            this.analytics_label_middle.AutoSize = true;
            this.analytics_label_middle.Dock = System.Windows.Forms.DockStyle.Left;
            this.analytics_label_middle.Location = new System.Drawing.Point(134, 18);
            this.analytics_label_middle.Name = "analytics_label_middle";
            this.analytics_label_middle.Size = new System.Drawing.Size(46, 17);
            this.analytics_label_middle.TabIndex = 1;
            this.analytics_label_middle.Text = "";
            // 
            // analytics_label_left
            // 
            this.analytics_label_left.AutoSize = true;
            this.analytics_label_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.analytics_label_left.Location = new System.Drawing.Point(3, 18);
            this.analytics_label_left.Name = "analytics_label_left";
            this.analytics_label_left.Size = new System.Drawing.Size(131, 17);
            this.analytics_label_left.TabIndex = 0;
            this.analytics_label_left.Text = "Nothing to compute";
            // 
            // correlationToolStripMenuItem
            // 
            this.correlationToolStripMenuItem.Name = "correlationToolStripMenuItem";
            this.correlationToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.correlationToolStripMenuItem.Text = "Correlation";
            this.correlationToolStripMenuItem.Click += new System.EventHandler(this.correlationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 495);
            this.Controls.Add(this.graphic_box);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "PlotBuilder (Toporov ©)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.graphic_box.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.analytics_box.ResumeLayout(false);
            this.analytics_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem func6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customRandomToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.GroupBox graphic_box;
        private System.Windows.Forms.ToolStripMenuItem analyticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
        private System.Windows.Forms.GroupBox analytics_box;
        private System.Windows.Forms.Label analytics_label_middle;
        private System.Windows.Forms.Label analytics_label_left;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripMenuItem hidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yaxbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ybeaxToolStripMenuItem;
        private System.Windows.Forms.Label analytics_label_right;
        private System.Windows.Forms.ToolStripMenuItem gistToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem correlationToolStripMenuItem;
    }
}

