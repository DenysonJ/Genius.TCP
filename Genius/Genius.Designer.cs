namespace Genius
{
    partial class Genius
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Genius));
            this.Start_button = new System.Windows.Forms.Button();
            this.timerAI = new System.Windows.Forms.Timer(this.components);
            this.Green_button = new System.Windows.Forms.PictureBox();
            this.Red_button = new System.Windows.Forms.PictureBox();
            this.Yellow_button = new System.Windows.Forms.PictureBox();
            this.Blue_button = new System.Windows.Forms.PictureBox();
            this.highscore_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Green_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yellow_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_button)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_button.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.ForeColor = System.Drawing.Color.DarkBlue;
            this.Start_button.Location = new System.Drawing.Point(275, 425);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(115, 25);
            this.Start_button.TabIndex = 4;
            this.Start_button.Text = "Start Game";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // timerAI
            // 
            this.timerAI.Interval = 400;
            this.timerAI.Tick += new System.EventHandler(this.timerIA_Tick);
            // 
            // Green_button
            // 
            this.Green_button.Enabled = false;
            this.Green_button.Image = global::Genius.Properties.Resources.green1;
            this.Green_button.Location = new System.Drawing.Point(1, 210);
            this.Green_button.Name = "Green_button";
            this.Green_button.Size = new System.Drawing.Size(204, 208);
            this.Green_button.TabIndex = 8;
            this.Green_button.TabStop = false;
            this.Green_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Green_button_MouseDown);
            this.Green_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Green_button_MouseUp);
            // 
            // Red_button
            // 
            this.Red_button.BackColor = System.Drawing.Color.Transparent;
            this.Red_button.Enabled = false;
            this.Red_button.Image = global::Genius.Properties.Resources.red1;
            this.Red_button.Location = new System.Drawing.Point(211, 210);
            this.Red_button.Name = "Red_button";
            this.Red_button.Size = new System.Drawing.Size(209, 208);
            this.Red_button.TabIndex = 7;
            this.Red_button.TabStop = false;
            this.Red_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Red_button_MouseDown);
            this.Red_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Red_button_MouseUp);
            // 
            // Yellow_button
            // 
            this.Yellow_button.BackColor = System.Drawing.Color.Transparent;
            this.Yellow_button.Enabled = false;
            this.Yellow_button.Image = global::Genius.Properties.Resources.yellow1;
            this.Yellow_button.Location = new System.Drawing.Point(211, 1);
            this.Yellow_button.Name = "Yellow_button";
            this.Yellow_button.Size = new System.Drawing.Size(209, 203);
            this.Yellow_button.TabIndex = 6;
            this.Yellow_button.TabStop = false;
            this.Yellow_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Yellow_button_MouseDown);
            this.Yellow_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Yellow_button_MouseUp);
            // 
            // Blue_button
            // 
            this.Blue_button.BackColor = System.Drawing.Color.Transparent;
            this.Blue_button.Enabled = false;
            this.Blue_button.Image = ((System.Drawing.Image)(resources.GetObject("Blue_button.Image")));
            this.Blue_button.Location = new System.Drawing.Point(1, 1);
            this.Blue_button.Name = "Blue_button";
            this.Blue_button.Size = new System.Drawing.Size(204, 203);
            this.Blue_button.TabIndex = 5;
            this.Blue_button.TabStop = false;
            this.Blue_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Blue_button_MouseDown);
            this.Blue_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Blue_button_MouseUp);
            // 
            // highscore_label
            // 
            this.highscore_label.AutoSize = true;
            this.highscore_label.Location = new System.Drawing.Point(13, 437);
            this.highscore_label.Name = "highscore_label";
            this.highscore_label.Size = new System.Drawing.Size(0, 13);
            this.highscore_label.TabIndex = 9;
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Location = new System.Drawing.Point(13, 405);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(0, 13);
            this.score_label.TabIndex = 10;
            // 
            // Genius
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(414, 461);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.highscore_label);
            this.Controls.Add(this.Green_button);
            this.Controls.Add(this.Red_button);
            this.Controls.Add(this.Yellow_button);
            this.Controls.Add(this.Blue_button);
            this.Controls.Add(this.Start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Genius";
            this.Text = "We are Genius";
            ((System.ComponentModel.ISupportInitialize)(this.Green_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yellow_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button Start_button;
        public System.Windows.Forms.Timer timerAI;
        public System.Windows.Forms.PictureBox Blue_button;
        public System.Windows.Forms.PictureBox Yellow_button;
        public System.Windows.Forms.PictureBox Red_button;
        public System.Windows.Forms.PictureBox Green_button;
        public System.Windows.Forms.Label highscore_label;
        public System.Windows.Forms.Label score_label;
    }
}

