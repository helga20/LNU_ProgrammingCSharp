namespace RadioGroupControl
{
    partial class RadioGroup
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
            this.theGrpBox = new System.Windows.Forms.GroupBox();
            this.theTableLtPnl = new System.Windows.Forms.TableLayoutPanel();
            this.theGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // theGrpBox
            // 
            this.theGrpBox.Controls.Add(this.theTableLtPnl);
            this.theGrpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theGrpBox.Location = new System.Drawing.Point(0, 0);
            this.theGrpBox.Name = "theGrpBox";
            this.theGrpBox.Size = new System.Drawing.Size(200, 100);
            this.theGrpBox.TabIndex = 0;
            this.theGrpBox.TabStop = false;
            // 
            // theTableLtPnl
            // 
            this.theTableLtPnl.ColumnCount = 1;
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.theTableLtPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theTableLtPnl.Location = new System.Drawing.Point(3, 16);
            this.theTableLtPnl.Name = "theTableLtPnl";
            this.theTableLtPnl.RowCount = 1;
            this.theTableLtPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.theTableLtPnl.Size = new System.Drawing.Size(194, 81);
            this.theTableLtPnl.TabIndex = 0;
            this.theTableLtPnl.DoubleClick += new System.EventHandler(this.theTableLtPnl_DoubleClick);
            // 
            // RadioGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.theGrpBox);
            this.Name = "RadioGroup";
            this.Size = new System.Drawing.Size(200, 100);
            this.theGrpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox theGrpBox;
        private System.Windows.Forms.TableLayoutPanel theTableLtPnl;
    }
}
