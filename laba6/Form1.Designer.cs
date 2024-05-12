namespace laba6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            label1 = new Label();
            lblDirection = new Label();
            tbDistribution = new TrackBar();
            label2 = new Label();
            lblDistribution = new Label();
            tbGraviton = new TrackBar();
            label3 = new Label();
            tbGraviton2 = new TrackBar();
            label4 = new Label();
            tbSpeedDeparture = new TrackBar();
            label7 = new Label();
            label10 = new Label();
            tbLife = new TrackBar();
            cbGraviton = new CheckBox();
            cbTeleport = new CheckBox();
            tbSizeTeletort = new TrackBar();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeedDeparture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLife).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSizeTeletort).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(776, 435);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseDown += picDisplay_MouseDown;
            picDisplay.MouseMove += picDisplay_MouseMove;
            picDisplay.MouseUp += picDisplay_MouseUp;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 474);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(184, 56);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 457);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 2;
            label1.Text = "Направление";
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(202, 480);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(0, 20);
            lblDirection.TabIndex = 3;
            // 
            // tbDistribution
            // 
            tbDistribution.Location = new Point(12, 536);
            tbDistribution.Maximum = 359;
            tbDistribution.Name = "tbDistribution";
            tbDistribution.Size = new Size(184, 56);
            tbDistribution.TabIndex = 4;
            tbDistribution.Scroll += tbDistribution_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 516);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 5;
            label2.Text = "Разброс";
            // 
            // lblDistribution
            // 
            lblDistribution.AutoSize = true;
            lblDistribution.Location = new Point(202, 536);
            lblDistribution.Name = "lblDistribution";
            lblDistribution.Size = new Size(0, 20);
            lblDistribution.TabIndex = 6;
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(268, 510);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(144, 56);
            tbGraviton.TabIndex = 7;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 487);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 8;
            label3.Text = "2 Гравитон";
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(268, 586);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(144, 56);
            tbGraviton2.TabIndex = 9;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 563);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 10;
            label4.Text = "1 Гравитон";
            // 
            // tbSpeedDeparture
            // 
            tbSpeedDeparture.Location = new Point(12, 589);
            tbSpeedDeparture.Maximum = 20;
            tbSpeedDeparture.Minimum = 5;
            tbSpeedDeparture.Name = "tbSpeedDeparture";
            tbSpeedDeparture.Size = new Size(184, 56);
            tbSpeedDeparture.TabIndex = 16;
            tbSpeedDeparture.Value = 5;
            tbSpeedDeparture.Scroll += tbSpeedDeparture_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 572);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 18;
            label7.Text = "Скорость";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 632);
            label10.Name = "label10";
            label10.Size = new Size(201, 20);
            label10.TabIndex = 22;
            label10.Text = "Продолжительность жизни";
            // 
            // tbLife
            // 
            tbLife.Location = new Point(12, 655);
            tbLife.Maximum = 100;
            tbLife.Minimum = 30;
            tbLife.Name = "tbLife";
            tbLife.Size = new Size(184, 56);
            tbLife.TabIndex = 23;
            tbLife.Value = 30;
            tbLife.Scroll += tbLife_Scroll;
            // 
            // cbGraviton
            // 
            cbGraviton.AutoSize = true;
            cbGraviton.Location = new Point(268, 457);
            cbGraviton.Name = "cbGraviton";
            cbGraviton.Size = new Size(96, 24);
            cbGraviton.TabIndex = 24;
            cbGraviton.Text = "Гравитон";
            cbGraviton.UseVisualStyleBackColor = true;
            cbGraviton.CheckedChanged += cbGraviton_CheckedChanged;
            // 
            // cbTeleport
            // 
            cbTeleport.AutoSize = true;
            cbTeleport.Location = new Point(442, 453);
            cbTeleport.Name = "cbTeleport";
            cbTeleport.Size = new Size(96, 24);
            cbTeleport.TabIndex = 25;
            cbTeleport.Text = "Телепорт";
            cbTeleport.UseVisualStyleBackColor = true;
            cbTeleport.CheckedChanged += cbTeleport_CheckedChanged;
            // 
            // tbSizeTeletort
            // 
            tbSizeTeletort.Location = new Point(432, 510);
            tbSizeTeletort.Maximum = 100;
            tbSizeTeletort.Minimum = 10;
            tbSizeTeletort.Name = "tbSizeTeletort";
            tbSizeTeletort.Size = new Size(144, 56);
            tbSizeTeletort.TabIndex = 26;
            tbSizeTeletort.Value = 10;
            tbSizeTeletort.Scroll += tbSizeTeletort_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 487);
            label5.Name = "label5";
            label5.Size = new Size(135, 20);
            label5.TabIndex = 27;
            label5.Text = "Размер телепорта";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 730);
            Controls.Add(label5);
            Controls.Add(tbSizeTeletort);
            Controls.Add(cbTeleport);
            Controls.Add(cbGraviton);
            Controls.Add(tbLife);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(tbSpeedDeparture);
            Controls.Add(label4);
            Controls.Add(tbGraviton2);
            Controls.Add(label3);
            Controls.Add(tbGraviton);
            Controls.Add(lblDistribution);
            Controls.Add(label2);
            Controls.Add(tbDistribution);
            Controls.Add(lblDirection);
            Controls.Add(label1);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeedDeparture).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLife).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSizeTeletort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label label1;
        private Label lblDirection;
        private TrackBar tbDistribution;
        private Label label2;
        private Label lblDistribution;
        private TrackBar tbGraviton;
        private Label label3;
        private TrackBar tbGraviton2;
        private Label label4;
        private TrackBar tbSpeedDeparture;
        private Label label7;
        private Label label10;
        private TrackBar tbLife;
        private CheckBox cbGraviton;
        private CheckBox cbTeleport;
        private TrackBar tbSizeTeletort;
        private Label label5;
    }
}
