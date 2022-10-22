namespace LabeledTextControl
{
    partial class LabeledTextbox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_Label = new System.Windows.Forms.Label();
            this.m_Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_Label
            // 
            this.m_Label.AutoSize = true;
            this.m_Label.Location = new System.Drawing.Point(0, 0);
            this.m_Label.Name = "m_Label";
            this.m_Label.Size = new System.Drawing.Size(10, 13);
            this.m_Label.TabIndex = 0;
            this.m_Label.Text = " ";
            // 
            // m_Text
            // 
            this.m_Text.Location = new System.Drawing.Point(0, 16);
            this.m_Text.Name = "m_Text";
            this.m_Text.Size = new System.Drawing.Size(170, 20);
            this.m_Text.TabIndex = 1;
            this.m_Text.TextChanged += new System.EventHandler(this.m_Text_TextChanged);
            this.m_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_Text_KeyDown);
            this.m_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_Text_KeyPress);
            this.m_Text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_Text_KeyUp);
            // 
            // LabeledTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_Text);
            this.Controls.Add(this.m_Label);
            this.Name = "LabeledTextbox";
            this.Size = new System.Drawing.Size(170, 37);
            this.FontChanged += new System.EventHandler(this.LabeledTextbox_FontChanged);
            this.SizeChanged += new System.EventHandler(this.LabeledTextbox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_Label;
        private System.Windows.Forms.TextBox m_Text;

    }
}
