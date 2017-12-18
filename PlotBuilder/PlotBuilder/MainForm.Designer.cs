namespace PlotBuilder
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMinXtxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMaxXtxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMinYtxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMaxYtxtBox = new System.Windows.Forms.ToolStripTextBox();
            this.trendsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impulseReactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antiTrendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testLPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lukoilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartBox = new System.Windows.Forms.GroupBox();
            this.myModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setToolStripMenuItem,
            this.trendsToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.discrToolStripMenuItem,
            this.fourierToolStripMenuItem,
            this.impulseReactToolStripMenuItem,
            this.testingToolStripMenuItem,
            this.lDFToolStripMenuItem,
            this.voiceToolStripMenuItem,
            this.kursToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // parseDataToolStripMenuItem
            // 
            this.parseDataToolStripMenuItem.Name = "parseDataToolStripMenuItem";
            this.parseDataToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.parseDataToolStripMenuItem.Text = "parse data";
            this.parseDataToolStripMenuItem.Click += new System.EventHandler(this.parseDataToolStripMenuItem_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMinXtxtBox,
            this.toolStripMaxXtxtBox,
            this.toolStripMinYtxtBox,
            this.toolStripMaxYtxtBox});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(42, 24);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // toolStripMinXtxtBox
            // 
            this.toolStripMinXtxtBox.Name = "toolStripMinXtxtBox";
            this.toolStripMinXtxtBox.Size = new System.Drawing.Size(100, 27);
            this.toolStripMinXtxtBox.Text = "min X: ";
            this.toolStripMinXtxtBox.Click += new System.EventHandler(this.toolStripMinXtxtBox_Click);
            this.toolStripMinXtxtBox.MouseLeave += new System.EventHandler(this.toolStripMinXtxtBox_MouseLeave);
            // 
            // toolStripMaxXtxtBox
            // 
            this.toolStripMaxXtxtBox.Name = "toolStripMaxXtxtBox";
            this.toolStripMaxXtxtBox.Size = new System.Drawing.Size(100, 27);
            this.toolStripMaxXtxtBox.Text = "max X: ";
            this.toolStripMaxXtxtBox.Click += new System.EventHandler(this.toolStripMaxXtxtBox_Click);
            this.toolStripMaxXtxtBox.MouseLeave += new System.EventHandler(this.toolStripMaxXtxtBox_MouseLeave);
            // 
            // toolStripMinYtxtBox
            // 
            this.toolStripMinYtxtBox.Name = "toolStripMinYtxtBox";
            this.toolStripMinYtxtBox.Size = new System.Drawing.Size(100, 27);
            this.toolStripMinYtxtBox.Text = "min Y: ";
            this.toolStripMinYtxtBox.Click += new System.EventHandler(this.toolStripMinYtxtBox_Click);
            this.toolStripMinYtxtBox.MouseLeave += new System.EventHandler(this.toolStripMinYtxtBox_MouseLeave);
            // 
            // toolStripMaxYtxtBox
            // 
            this.toolStripMaxYtxtBox.Name = "toolStripMaxYtxtBox";
            this.toolStripMaxYtxtBox.Size = new System.Drawing.Size(100, 27);
            this.toolStripMaxYtxtBox.Text = "max Y: ";
            this.toolStripMaxYtxtBox.Click += new System.EventHandler(this.toolStripMaxYtxtBox_Click);
            this.toolStripMaxYtxtBox.MouseLeave += new System.EventHandler(this.toolStripMaxYtxtBox_MouseLeave);
            // 
            // trendsToolStripMenuItem
            // 
            this.trendsToolStripMenuItem.Name = "trendsToolStripMenuItem";
            this.trendsToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.trendsToolStripMenuItem.Text = "Trends";
            this.trendsToolStripMenuItem.Click += new System.EventHandler(this.trendsToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.crossToolStripMenuItem,
            this.gistToolStripMenuItem});
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.randomToolStripMenuItem.Text = "Random";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // crossToolStripMenuItem
            // 
            this.crossToolStripMenuItem.Name = "crossToolStripMenuItem";
            this.crossToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.crossToolStripMenuItem.Text = "Cross";
            this.crossToolStripMenuItem.Click += new System.EventHandler(this.crossToolStripMenuItem_Click);
            // 
            // gistToolStripMenuItem
            // 
            this.gistToolStripMenuItem.Name = "gistToolStripMenuItem";
            this.gistToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.gistToolStripMenuItem.Text = "Gist";
            this.gistToolStripMenuItem.Click += new System.EventHandler(this.gistToolStripMenuItem_Click);
            // 
            // discrToolStripMenuItem
            // 
            this.discrToolStripMenuItem.Name = "discrToolStripMenuItem";
            this.discrToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.discrToolStripMenuItem.Text = "Discr";
            this.discrToolStripMenuItem.Click += new System.EventHandler(this.discrToolStripMenuItem_Click);
            // 
            // fourierToolStripMenuItem
            // 
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            this.fourierToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.fourierToolStripMenuItem.Text = "Fourier";
            this.fourierToolStripMenuItem.Click += new System.EventHandler(this.fourierToolStripMenuItem_Click);
            // 
            // impulseReactToolStripMenuItem
            // 
            this.impulseReactToolStripMenuItem.Name = "impulseReactToolStripMenuItem";
            this.impulseReactToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.impulseReactToolStripMenuItem.Text = "Impulse React";
            this.impulseReactToolStripMenuItem.Click += new System.EventHandler(this.impulseReactToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.antiTrendToolStripMenuItem,
            this.testLPFToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // antiTrendToolStripMenuItem
            // 
            this.antiTrendToolStripMenuItem.Name = "antiTrendToolStripMenuItem";
            this.antiTrendToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.antiTrendToolStripMenuItem.Text = "AntiTrend";
            this.antiTrendToolStripMenuItem.Click += new System.EventHandler(this.antiTrendToolStripMenuItem_Click);
            // 
            // testLPFToolStripMenuItem
            // 
            this.testLPFToolStripMenuItem.Name = "testLPFToolStripMenuItem";
            this.testLPFToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.testLPFToolStripMenuItem.Text = "testLPF";
            this.testLPFToolStripMenuItem.Click += new System.EventHandler(this.testLPFToolStripMenuItem_Click);
            // 
            // lDFToolStripMenuItem
            // 
            this.lDFToolStripMenuItem.Name = "lDFToolStripMenuItem";
            this.lDFToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.lDFToolStripMenuItem.Text = "Filters";
            this.lDFToolStripMenuItem.Click += new System.EventHandler(this.lDFToolStripMenuItem_Click);
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.voiceToolStripMenuItem.Text = "Voice";
            this.voiceToolStripMenuItem.Click += new System.EventHandler(this.voiceToolStripMenuItem_Click);
            // 
            // kursToolStripMenuItem
            // 
            this.kursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lukoilToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.myModelToolStripMenuItem});
            this.kursToolStripMenuItem.Name = "kursToolStripMenuItem";
            this.kursToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.kursToolStripMenuItem.Text = "Kurs";
            // 
            // lukoilToolStripMenuItem
            // 
            this.lukoilToolStripMenuItem.Name = "lukoilToolStripMenuItem";
            this.lukoilToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.lukoilToolStripMenuItem.Text = "Lukoil";
            this.lukoilToolStripMenuItem.Click += new System.EventHandler(this.lukoilToolStripMenuItem_Click);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // chartBox
            // 
            this.chartBox.AutoSize = true;
            this.chartBox.BackColor = System.Drawing.SystemColors.Control;
            this.chartBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBox.Location = new System.Drawing.Point(0, 28);
            this.chartBox.Name = "chartBox";
            this.chartBox.Size = new System.Drawing.Size(983, 515);
            this.chartBox.TabIndex = 2;
            this.chartBox.TabStop = false;
            // 
            // myModelToolStripMenuItem
            // 
            this.myModelToolStripMenuItem.Name = "myModelToolStripMenuItem";
            this.myModelToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.myModelToolStripMenuItem.Text = "My model";
            this.myModelToolStripMenuItem.Click += new System.EventHandler(this.myModelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(983, 543);
            this.Controls.Add(this.chartBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PlotBuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trendsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.GroupBox chartBox;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripMinXtxtBox;
        private System.Windows.Forms.ToolStripTextBox toolStripMaxXtxtBox;
        private System.Windows.Forms.ToolStripTextBox toolStripMinYtxtBox;
        private System.Windows.Forms.ToolStripTextBox toolStripMaxYtxtBox;
        private System.Windows.Forms.ToolStripMenuItem gistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impulseReactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antiTrendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLPFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lukoilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myModelToolStripMenuItem;
    }
}

