namespace balls_game
{
    partial class level_5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(level_5));
            this.result5_label = new System.Windows.Forms.Label();
            this.play5_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result5_label
            // 
            this.result5_label.AutoSize = true;
            this.result5_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Italic);
            this.result5_label.ForeColor = System.Drawing.Color.White;
            this.result5_label.Location = new System.Drawing.Point(12, 9);
            this.result5_label.Name = "result5_label";
            this.result5_label.Size = new System.Drawing.Size(97, 32);
            this.result5_label.TabIndex = 0;
            this.result5_label.Text = "Result";
            // 
            // play5_button
            // 
            this.play5_button.BackColor = System.Drawing.Color.Black;
            this.play5_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play5_button.Font = new System.Drawing.Font("MV Boli", 27.75F);
            this.play5_button.ForeColor = System.Drawing.Color.Yellow;
            this.play5_button.Location = new System.Drawing.Point(300, 15);
            this.play5_button.Name = "play5_button";
            this.play5_button.Size = new System.Drawing.Size(130, 55);
            this.play5_button.TabIndex = 1;
            this.play5_button.Text = "Play";
            this.play5_button.UseVisualStyleBackColor = false;
            this.play5_button.Click += new System.EventHandler(this.play5_button_Click);
            // 
            // level_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.play5_button);
            this.Controls.Add(this.result5_label);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "level_5";
            this.Text = "5 рівень";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label result5_label;
        private System.Windows.Forms.Button play5_button;
    }
}