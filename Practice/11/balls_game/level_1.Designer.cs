namespace balls_game
{
    partial class level_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(level_1));
            this.result1_label = new System.Windows.Forms.Label();
            this.play1_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result1_label
            // 
            this.result1_label.AutoSize = true;
            this.result1_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result1_label.ForeColor = System.Drawing.Color.White;
            this.result1_label.Location = new System.Drawing.Point(12, 9);
            this.result1_label.Name = "result1_label";
            this.result1_label.Size = new System.Drawing.Size(97, 32);
            this.result1_label.TabIndex = 0;
            this.result1_label.Text = "Result";
            // 
            // play1_button
            // 
            this.play1_button.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.play1_button.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play1_button.ForeColor = System.Drawing.Color.Yellow;
            this.play1_button.Location = new System.Drawing.Point(300, 15);
            this.play1_button.Name = "play1_button";
            this.play1_button.Size = new System.Drawing.Size(130, 55);
            this.play1_button.TabIndex = 1;
            this.play1_button.Text = "Play";
            this.play1_button.UseVisualStyleBackColor = false;
            this.play1_button.Click += new System.EventHandler(this.play1_button_Click);
            // 
            // level_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.play1_button);
            this.Controls.Add(this.result1_label);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "level_1";
            this.Text = "1 рівень";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label result1_label;
        private System.Windows.Forms.Button play1_button;
    }
}