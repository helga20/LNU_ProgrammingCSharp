namespace balls_game
{
    partial class balls_game_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(balls_game_main));
            this.level1 = new System.Windows.Forms.Label();
            this.level2 = new System.Windows.Forms.Label();
            this.level3 = new System.Windows.Forms.Label();
            this.level4 = new System.Windows.Forms.Label();
            this.levels_comboBox = new System.Windows.Forms.ComboBox();
            this.play_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.level5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // level1
            // 
            this.level1.AutoSize = true;
            this.level1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level1.Location = new System.Drawing.Point(12, 9);
            this.level1.Name = "level1";
            this.level1.Size = new System.Drawing.Size(231, 16);
            this.level1.TabIndex = 0;
            this.level1.Text = "Найкращий результат 1 рівня:";
            // 
            // level2
            // 
            this.level2.AutoSize = true;
            this.level2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level2.Location = new System.Drawing.Point(12, 44);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(231, 16);
            this.level2.TabIndex = 1;
            this.level2.Text = "Найкращий результат 2 рівня:";
            // 
            // level3
            // 
            this.level3.AutoSize = true;
            this.level3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level3.Location = new System.Drawing.Point(12, 80);
            this.level3.Name = "level3";
            this.level3.Size = new System.Drawing.Size(231, 16);
            this.level3.TabIndex = 2;
            this.level3.Text = "Найкращий результат 3 рівня:";
            // 
            // level4
            // 
            this.level4.AutoSize = true;
            this.level4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.level4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level4.Location = new System.Drawing.Point(12, 118);
            this.level4.Name = "level4";
            this.level4.Size = new System.Drawing.Size(231, 16);
            this.level4.TabIndex = 3;
            this.level4.Text = "Найкращий результат 4 рівня:";
            // 
            // levels_comboBox
            // 
            this.levels_comboBox.FormattingEnabled = true;
            this.levels_comboBox.Items.AddRange(new object[] {
            "1 рівень",
            "2 рівень",
            "3 рівень",
            "4 рівень",
            "5 рівень"});
            this.levels_comboBox.Location = new System.Drawing.Point(12, 248);
            this.levels_comboBox.Name = "levels_comboBox";
            this.levels_comboBox.Size = new System.Drawing.Size(228, 21);
            this.levels_comboBox.TabIndex = 5;
            // 
            // play_button
            // 
            this.play_button.BackColor = System.Drawing.Color.Azure;
            this.play_button.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_button.ForeColor = System.Drawing.Color.Gold;
            this.play_button.Location = new System.Drawing.Point(15, 356);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(228, 73);
            this.play_button.TabIndex = 6;
            this.play_button.Text = "Play";
            this.play_button.UseVisualStyleBackColor = false;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.update_button.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold);
            this.update_button.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.update_button.Location = new System.Drawing.Point(361, 356);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(228, 73);
            this.update_button.TabIndex = 7;
            this.update_button.Tag = "";
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // level5
            // 
            this.level5.AutoSize = true;
            this.level5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.level5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.level5.Location = new System.Drawing.Point(12, 154);
            this.level5.Name = "level5";
            this.level5.Size = new System.Drawing.Size(231, 16);
            this.level5.TabIndex = 9;
            this.level5.Text = "Найкращий результат 5 рівня:";
            // 
            // balls_game_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(759, 441);
            this.Controls.Add(this.level5);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.levels_comboBox);
            this.Controls.Add(this.level4);
            this.Controls.Add(this.level3);
            this.Controls.Add(this.level2);
            this.Controls.Add(this.level1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "balls_game_main";
            this.Text = "Game Balls";
            this.Load += new System.EventHandler(this.balls_game_main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label level1;
        private System.Windows.Forms.Label level2;
        private System.Windows.Forms.Label level3;
        private System.Windows.Forms.Label level4;
        private System.Windows.Forms.ComboBox levels_comboBox;
        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Label level5;
    }
}

