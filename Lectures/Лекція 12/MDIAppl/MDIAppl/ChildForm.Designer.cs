namespace MDIAppl
{
    partial class ChildForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item21ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(668, 370);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(668, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item11ToolStripMenuItem,
            this.item12ToolStripMenuItem});
            this.item1ToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.item1ToolStripMenuItem.MergeIndex = 1;
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.item1ToolStripMenuItem.Text = "Item1";
            // 
            // item11ToolStripMenuItem
            // 
            this.item11ToolStripMenuItem.Name = "item11ToolStripMenuItem";
            this.item11ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.item11ToolStripMenuItem.Text = "Item11";
            // 
            // item12ToolStripMenuItem
            // 
            this.item12ToolStripMenuItem.Name = "item12ToolStripMenuItem";
            this.item12ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.item12ToolStripMenuItem.Text = "Item12";
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item21ToolStripMenuItem});
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.item2ToolStripMenuItem.Text = "Item2";
            // 
            // item21ToolStripMenuItem
            // 
            this.item21ToolStripMenuItem.Name = "item21ToolStripMenuItem";
            this.item21ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.item21ToolStripMenuItem.Text = "Item21";
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 394);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item21ToolStripMenuItem;
    }
}