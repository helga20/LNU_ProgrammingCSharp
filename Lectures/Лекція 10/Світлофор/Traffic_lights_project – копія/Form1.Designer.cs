namespace Traffic_lights_project
{
    partial class Traffic_lights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traffic_lights));
            this.Red = new System.Windows.Forms.PictureBox();
            this.Yellow = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.Button();
            this.end_button = new System.Windows.Forms.Button();
            this.light_timer = new System.Windows.Forms.Timer(this.components);
            this.Green = new System.Windows.Forms.PictureBox();
            this.RedButton = new System.Windows.Forms.Button();
            this.YellowButton = new System.Windows.Forms.Button();
            this.GreenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
            this.SuspendLayout();
            // 
            // Red
            // 
            this.Red.Image = ((System.Drawing.Image)(resources.GetObject("Red.Image")));
            this.Red.Location = new System.Drawing.Point(52, 35);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(261, 326);
            this.Red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Red.TabIndex = 1;
            this.Red.TabStop = false;
            // 
            // Yellow
            // 
            this.Yellow.Image = ((System.Drawing.Image)(resources.GetObject("Yellow.Image")));
            this.Yellow.Location = new System.Drawing.Point(52, 36);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(263, 326);
            this.Yellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Yellow.TabIndex = 2;
            this.Yellow.TabStop = false;
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.LightGray;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start_button.Location = new System.Drawing.Point(356, 36);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(122, 23);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "Почати";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // end_button
            // 
            this.end_button.BackColor = System.Drawing.Color.LightGray;
            this.end_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.end_button.Location = new System.Drawing.Point(356, 338);
            this.end_button.Name = "end_button";
            this.end_button.Size = new System.Drawing.Size(122, 23);
            this.end_button.TabIndex = 5;
            this.end_button.Text = "Закінчити";
            this.end_button.UseVisualStyleBackColor = false;
            this.end_button.Click += new System.EventHandler(this.end_button_Click);
            // 
            // light_timer
            // 
            this.light_timer.Tick += new System.EventHandler(this.light_timer_Tick);
            // 
            // Green
            // 
            this.Green.Image = ((System.Drawing.Image)(resources.GetObject("Green.Image")));
            this.Green.Location = new System.Drawing.Point(51, 36);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(264, 325);
            this.Green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Green.TabIndex = 6;
            this.Green.TabStop = false;
            // 
            // RedButton
            // 
            this.RedButton.BackColor = System.Drawing.Color.Red;
            this.RedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedButton.Location = new System.Drawing.Point(356, 144);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(122, 44);
            this.RedButton.TabIndex = 7;
            this.RedButton.Text = "Червоне світло";
            this.RedButton.UseVisualStyleBackColor = false;
            this.RedButton.Click += new System.EventHandler(this.RedButton_Click);
            // 
            // YellowButton
            // 
            this.YellowButton.BackColor = System.Drawing.Color.Yellow;
            this.YellowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YellowButton.Location = new System.Drawing.Point(356, 185);
            this.YellowButton.Name = "YellowButton";
            this.YellowButton.Size = new System.Drawing.Size(122, 41);
            this.YellowButton.TabIndex = 8;
            this.YellowButton.Text = "Жовте світло";
            this.YellowButton.UseVisualStyleBackColor = false;
            this.YellowButton.Click += new System.EventHandler(this.YellowButton_Click);
            // 
            // GreenButton
            // 
            this.GreenButton.BackColor = System.Drawing.Color.Lime;
            this.GreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GreenButton.Location = new System.Drawing.Point(356, 225);
            this.GreenButton.Name = "GreenButton";
            this.GreenButton.Size = new System.Drawing.Size(122, 41);
            this.GreenButton.TabIndex = 9;
            this.GreenButton.Text = "Зелене світло";
            this.GreenButton.UseVisualStyleBackColor = false;
            this.GreenButton.Click += new System.EventHandler(this.GreenButton_Click);
            // 
            // Traffic_lights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(514, 399);
            this.Controls.Add(this.GreenButton);
            this.Controls.Add(this.YellowButton);
            this.Controls.Add(this.RedButton);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.end_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Red);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Traffic_lights";
            this.Text = "Світлофор";
            ((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Red;
        private System.Windows.Forms.PictureBox Yellow;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button end_button;
        private System.Windows.Forms.Timer light_timer;
        private System.Windows.Forms.PictureBox Green;
        private System.Windows.Forms.Button RedButton;
        private System.Windows.Forms.Button YellowButton;
        private System.Windows.Forms.Button GreenButton;
    }
}

