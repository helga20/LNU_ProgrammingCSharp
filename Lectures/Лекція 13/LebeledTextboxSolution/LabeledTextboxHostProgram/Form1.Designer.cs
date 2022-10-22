﻿namespace LabeledTextboxHostProgram
{
    partial class Form1
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
            this.LabelTextButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.labeledTextbox1 = new LebeledTextboxControl.LabeledTextbox();
            this.SuspendLayout();
            // 
            // LabelTextButton
            // 
            this.LabelTextButton.Location = new System.Drawing.Point(12, 71);
            this.LabelTextButton.Name = "LabelTextButton";
            this.LabelTextButton.Size = new System.Drawing.Size(75, 23);
            this.LabelTextButton.TabIndex = 1;
            this.LabelTextButton.Text = "Hello";
            this.LabelTextButton.UseVisualStyleBackColor = true;
            this.LabelTextButton.Click += new System.EventHandler(this.LabelTextButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(105, 74);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Below";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(165, 74);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(50, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Right";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // labeledTextbox1
            // 
            this.labeledTextbox1.LabelText = "Який компонент хочете збудувати?";
            this.labeledTextbox1.Location = new System.Drawing.Point(12, 36);
            this.labeledTextbox1.Name = "labeledTextbox1";
            this.labeledTextbox1.Position = LebeledTextboxControl.LabeledTextbox.PositionEnum.Right;
            this.labeledTextbox1.Size = new System.Drawing.Size(298, 20);
            this.labeledTextbox1.TabIndex = 0;
            this.labeledTextbox1.TextboxMargin = 187;
            this.labeledTextbox1.TextboxText = "I do not now!";
            this.labeledTextbox1.TextChanged += new System.EventHandler(this.labeledTextbox1_TextChanged);
            this.labeledTextbox1.PositionChanged += new System.EventHandler(this.labeledTextbox1_PositionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 201);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.LabelTextButton);
            this.Controls.Add(this.labeledTextbox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LebeledTextboxControl.LabeledTextbox labeledTextbox1;
        private System.Windows.Forms.Button LabelTextButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

