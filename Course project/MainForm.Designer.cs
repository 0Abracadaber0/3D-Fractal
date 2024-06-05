namespace Course_project
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.distanceTextBox = new System.Windows.Forms.TextBox();
            this.spacingFactorTextBox = new System.Windows.Forms.TextBox();
            this.recursionDepthTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.darkTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьМодельВBlenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьМодельВBlenderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Расстояние до камеры:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Расстояние между кубами:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Глубина рекурсии:";
            // 
            // distanceTextBox
            // 
            this.distanceTextBox.BackColor = System.Drawing.Color.Black;
            this.distanceTextBox.ForeColor = System.Drawing.Color.White;
            this.distanceTextBox.Location = new System.Drawing.Point(176, 41);
            this.distanceTextBox.Name = "distanceTextBox";
            this.distanceTextBox.Size = new System.Drawing.Size(100, 22);
            this.distanceTextBox.TabIndex = 8;
            this.distanceTextBox.Text = "10";
            this.distanceTextBox.TextChanged += new System.EventHandler(this.ChangedDistance);
            // 
            // spacingFactorTextBox
            // 
            this.spacingFactorTextBox.BackColor = System.Drawing.Color.Black;
            this.spacingFactorTextBox.ForeColor = System.Drawing.Color.White;
            this.spacingFactorTextBox.Location = new System.Drawing.Point(201, 79);
            this.spacingFactorTextBox.Name = "spacingFactorTextBox";
            this.spacingFactorTextBox.Size = new System.Drawing.Size(100, 22);
            this.spacingFactorTextBox.TabIndex = 9;
            this.spacingFactorTextBox.Text = "1";
            this.spacingFactorTextBox.TextChanged += new System.EventHandler(this.ChangedSpacingFactor);
            // 
            // recursionDepthTextBox
            // 
            this.recursionDepthTextBox.BackColor = System.Drawing.Color.Black;
            this.recursionDepthTextBox.ForeColor = System.Drawing.Color.White;
            this.recursionDepthTextBox.Location = new System.Drawing.Point(148, 119);
            this.recursionDepthTextBox.Name = "recursionDepthTextBox";
            this.recursionDepthTextBox.Size = new System.Drawing.Size(100, 22);
            this.recursionDepthTextBox.TabIndex = 10;
            this.recursionDepthTextBox.Text = "4";
            this.recursionDepthTextBox.TextChanged += new System.EventHandler(this.ChangedRecursionDepth);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.видToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.rotateButton,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightTheme,
            this.darkTheme});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // lightTheme
            // 
            this.lightTheme.Name = "lightTheme";
            this.lightTheme.Size = new System.Drawing.Size(184, 26);
            this.lightTheme.Text = "Светлая тема";
            this.lightTheme.Click += new System.EventHandler(this.SetLightTheme);
            // 
            // darkTheme
            // 
            this.darkTheme.Checked = true;
            this.darkTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.darkTheme.Name = "darkTheme";
            this.darkTheme.Size = new System.Drawing.Size(184, 26);
            this.darkTheme.Text = "Темная тема";
            this.darkTheme.Click += new System.EventHandler(this.SetDarkTheme);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьМодельВBlenderToolStripMenuItem,
            this.сохранитьМодельВBlenderToolStripMenuItem1});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(97, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьМодельВBlenderToolStripMenuItem
            // 
            this.сохранитьМодельВBlenderToolStripMenuItem.Name = "сохранитьМодельВBlenderToolStripMenuItem";
            this.сохранитьМодельВBlenderToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.сохранитьМодельВBlenderToolStripMenuItem.Text = "Сохранить модель obj";
            this.сохранитьМодельВBlenderToolStripMenuItem.Click += new System.EventHandler(this.SaveModelClick);
            // 
            // сохранитьМодельВBlenderToolStripMenuItem1
            // 
            this.сохранитьМодельВBlenderToolStripMenuItem1.Name = "сохранитьМодельВBlenderToolStripMenuItem1";
            this.сохранитьМодельВBlenderToolStripMenuItem1.Size = new System.Drawing.Size(289, 26);
            this.сохранитьМодельВBlenderToolStripMenuItem1.Text = "Сохранить модель в Blender";
            this.сохранитьМодельВBlenderToolStripMenuItem1.Click += new System.EventHandler(this.SaveBlenderClick);
            // 
            // rotateButton
            // 
            this.rotateButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(98, 26);
            this.rotateButton.Text = "Вращение";
            this.rotateButton.Click += new System.EventHandler(this.RotateClick);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.OpenHelpFile);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.recursionDepthTextBox);
            this.Controls.Add(this.spacingFactorTextBox);
            this.Controls.Add(this.distanceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox distanceTextBox;
        private System.Windows.Forms.TextBox spacingFactorTextBox;
        private System.Windows.Forms.TextBox recursionDepthTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightTheme;
        private System.Windows.Forms.ToolStripMenuItem darkTheme;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьМодельВBlenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьМодельВBlenderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotateButton;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    }
}
