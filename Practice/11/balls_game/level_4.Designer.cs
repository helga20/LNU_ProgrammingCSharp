namespace balls_game
{
    partial class level_4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(level_4));
            this.result4_label = new System.Windows.Forms.Label();
            this.play4_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result4_label
            // 
            this.result4_label.AutoSize = true;
            this.result4_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Italic);
            this.result4_label.ForeColor = System.Drawing.Color.White;
            this.result4_label.Location = new System.Drawing.Point(12, 9);
            this.result4_label.Name = "result4_label";
            this.result4_label.Size = new System.Drawing.Size(97, 32);
            this.result4_label.TabIndex = 0;
            this.result4_label.Text = "Result";
            // 
            // play4_button
            // 
            this.play4_button.BackColor = System.Drawing.Color.Black;
            this.play4_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play4_button.Font = new System.Drawing.Font("MV Boli", 27.75F);
            this.play4_button.ForeColor = System.Drawing.Color.Yellow;
            this.play4_button.Location = new System.Drawing.Point(300, 15);
            this.play4_button.Name = "play4_button";
            this.play4_button.Size = new System.Drawing.Size(130, 55);
            this.play4_button.TabIndex = 1;
            this.play4_button.Text = "Play";
            this.play4_button.UseVisualStyleBackColor = false;
            this.play4_button.Click += new System.EventHandler(this.play4_button_Click);
            // 
            // level_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.play4_button);
            this.Controls.Add(this.result4_label);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "level_4";
            this.Text = "4 рівень";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label result4_label;
        private System.Windows.Forms.Button play4_button;
    }
}