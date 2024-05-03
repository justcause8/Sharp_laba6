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
            tbRadius = new TrackBar();
            tbSpeed = new TrackBar();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(776, 341);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 376);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(184, 56);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 359);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 2;
            label1.Text = "Направление";
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(202, 382);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(0, 20);
            lblDirection.TabIndex = 3;
            // 
            // tbDistribution
            // 
            tbDistribution.Location = new Point(12, 438);
            tbDistribution.Maximum = 359;
            tbDistribution.Name = "tbDistribution";
            tbDistribution.Size = new Size(184, 56);
            tbDistribution.TabIndex = 4;
            tbDistribution.Scroll += tbDistribution_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 418);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 5;
            label2.Text = "Разброс";
            // 
            // lblDistribution
            // 
            lblDistribution.AutoSize = true;
            lblDistribution.Location = new Point(202, 438);
            lblDistribution.Name = "lblDistribution";
            lblDistribution.Size = new Size(0, 20);
            lblDistribution.TabIndex = 6;
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(241, 376);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(144, 56);
            tbGraviton.TabIndex = 7;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 359);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 8;
            label3.Text = "2 Гравитон";
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(241, 438);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(144, 56);
            tbGraviton2.TabIndex = 9;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(241, 418);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 10;
            label4.Text = "1 Гравитон";
            // 
            // tbRadius
            // 
            tbRadius.Location = new Point(818, 34);
            tbRadius.Name = "tbRadius";
            tbRadius.Size = new Size(181, 56);
            tbRadius.TabIndex = 11;
            tbRadius.Scroll += tbRadius_Scroll;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new Point(818, 96);
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new Size(181, 56);
            tbSpeed.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(817, 9);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 13;
            label5.Text = "Радиус";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(817, 73);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 14;
            label6.Text = "Скорость";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 501);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(tbSpeed);
            Controls.Add(tbRadius);
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
            ((System.ComponentModel.ISupportInitialize)tbRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
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
        private TrackBar tbRadius;
        private TrackBar tbSpeed;
        private Label label5;
        private Label label6;
    }
}
