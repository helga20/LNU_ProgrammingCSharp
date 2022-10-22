namespace LabeledTextboxHost
{
    partial class HostForm
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
            this.labeledTextbox1 = new LabeledTextControl.LabeledTextbox();
            this.labeledTextbox2 = new LabeledTextControl.LabeledTextbox();
            this.labeledTextbox3 = new LabeledTextControl.LabeledTextbox();
            this.labeledTextbox4 = new LabeledTextControl.LabeledTextbox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labeledTextbox1
            // 
            this.labeledTextbox1.LabelText = "Прізвище";
            this.labeledTextbox1.Location = new System.Drawing.Point(12, 12);
            this.labeledTextbox1.Name = "labeledTextbox1";
            this.labeledTextbox1.Size = new System.Drawing.Size(170, 36);
            this.labeledTextbox1.TabIndex = 0;
            this.labeledTextbox1.TextboxText = "";
            this.labeledTextbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labeledTextbox1_KeyPress);
            // 
            // labeledTextbox2
            // 
            this.labeledTextbox2.LabelText = "Ім\'я";
            this.labeledTextbox2.Location = new System.Drawing.Point(12, 54);
            this.labeledTextbox2.Name = "labeledTextbox2";
            this.labeledTextbox2.Size = new System.Drawing.Size(170, 36);
            this.labeledTextbox2.TabIndex = 1;
            this.labeledTextbox2.TextboxText = "";
            this.labeledTextbox2.PositionChanged += new System.EventHandler(this.labeledTextbox2_PositionChanged);
            // 
            // labeledTextbox3
            // 
            this.labeledTextbox3.LabelText = "Адреса";
            this.labeledTextbox3.Location = new System.Drawing.Point(12, 96);
            this.labeledTextbox3.Name = "labeledTextbox3";
            this.labeledTextbox3.Size = new System.Drawing.Size(170, 36);
            this.labeledTextbox3.TabIndex = 2;
            this.labeledTextbox3.TextboxText = "";
            this.labeledTextbox3.TextChanged += new System.EventHandler(this.labeledTextbox3_TextChanged);
            // 
            // labeledTextbox4
            // 
            this.labeledTextbox4.LabelText = "Останнє поле";
            this.labeledTextbox4.Location = new System.Drawing.Point(12, 151);
            this.labeledTextbox4.Name = "labeledTextbox4";
            this.labeledTextbox4.Position = LabeledTextControl.LabeledTextbox.PositionEnum.Right;
            this.labeledTextbox4.Size = new System.Drawing.Size(170, 20);
            this.labeledTextbox4.TabIndex = 3;
            this.labeledTextbox4.TextboxMargin = 77;
            this.labeledTextbox4.TextboxText = "";
            this.labeledTextbox4.Leave += new System.EventHandler(this.labeledTextbox4_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labeledTextbox4);
            this.Controls.Add(this.labeledTextbox3);
            this.Controls.Add(this.labeledTextbox2);
            this.Controls.Add(this.labeledTextbox1);
            this.Name = "HostForm";
            this.Text = "Test Labeled text in action";
            this.ResumeLayout(false);

        }

        #endregion

        private LabeledTextControl.LabeledTextbox labeledTextbox1;
        private LabeledTextControl.LabeledTextbox labeledTextbox2;
        private LabeledTextControl.LabeledTextbox labeledTextbox3;
        private LabeledTextControl.LabeledTextbox labeledTextbox4;
        private System.Windows.Forms.Button button1;
    }
}

