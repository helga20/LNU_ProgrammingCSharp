namespace balls_game
{
    partial class level_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(level_2));
            this.result2_label = new System.Windows.Forms.Label();
            this.play2_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result2_label
            // 
            this.result2_label.AutoSize = true;
            this.result2_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.result2_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Italic);
            this.result2_label.ForeColor = System.Drawing.Color.White;
            this.result2_label.Location = new System.Drawing.Point(12, 9);
            this.result2_label.Name = "result2_label";
            this.result2_label.Size = new System.Drawing.Size(97, 32);
            this.result2_label.TabIndex = 0;
            this.result2_label.Text = "Result";
            // 
            // play2_button
            // 
            this.play2_button.BackColor = System.Drawing.Color.Black;
            this.play2_button.Font = new System.Drawing.Font("MV Boli", 27.75F);
            this.play2_button.ForeColor = System.Drawing.Color.Yellow;
            this.play2_button.Location = new System.Drawing.Point(300, 15);
            this.play2_button.Name = "play2_button";
            this.play2_button.Size = new System.Drawing.Size(130, 55);
            this.play2_button.TabIndex = 1;
            this.play2_button.Text = "Play";
            this.play2_button.UseVisualStyleBackColor = false;
            this.play2_button.Click += new System.EventHandler(this.play2_button_Click);
            // 
            // level_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.play2_button);
            this.Controls.Add(this.result2_label);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "level_2";
            this.Text = "2 рівень";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label result2_label;
        private System.Windows.Forms.Button play2_button;
    }
}