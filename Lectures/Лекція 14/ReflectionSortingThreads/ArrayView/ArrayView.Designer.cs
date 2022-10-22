namespace ArrayView
{
    partial class ArrayView
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
            this.viewPanel = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.cmbMethods = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewPanel.Location = new System.Drawing.Point(0, 24);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(177, 520);
            this.viewPanel.TabIndex = 0;
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPanel_Paint);
            // 
            // viewButton
            // 
            this.viewButton.Image = global::ArrayView.Properties.Resources.stop;
            this.viewButton.Location = new System.Drawing.Point(156, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(18, 18);
            this.viewButton.TabIndex = 1;
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Visible = false;
            this.viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // cmbMethods
            // 
            this.cmbMethods.FormattingEnabled = true;
            this.cmbMethods.Location = new System.Drawing.Point(0, 0);
            this.cmbMethods.Name = "cmbMethods";
            this.cmbMethods.Size = new System.Drawing.Size(150, 21);
            this.cmbMethods.TabIndex = 2;
            this.cmbMethods.Text = "Select an algorithm";
            this.cmbMethods.SelectedIndexChanged += new System.EventHandler(this.CmbMethods_SelectedIndexChanged);
            // 
            // ArrayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbMethods);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.viewPanel);
            this.Name = "ArrayView";
            this.Size = new System.Drawing.Size(177, 545);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.ComboBox cmbMethods;
    }
}
