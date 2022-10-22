namespace ReflectionSortingThreads
{
    partial class VisualForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.aLabel = new System.Windows.Forms.Label();
            this.sizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnSort = new System.Windows.Forms.Button();
            this.cmBoxGen = new System.Windows.Forms.ComboBox();
            this.bLabel = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(228, 15);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add thread";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(384, 15);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(140, 28);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove thread";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(576, 21);
            this.aLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(88, 17);
            this.aLabel.TabIndex = 2;
            this.aLabel.Text = "Size of array";
            // 
            // sizeUpDown
            // 
            this.sizeUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sizeUpDown.Location = new System.Drawing.Point(671, 18);
            this.sizeUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.sizeUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.sizeUpDown.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.sizeUpDown.Name = "sizeUpDown";
            this.sizeUpDown.Size = new System.Drawing.Size(59, 22);
            this.sizeUpDown.TabIndex = 3;
            this.sizeUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // btnSort
            // 
            this.btnSort.Enabled = false;
            this.btnSort.Location = new System.Drawing.Point(779, 15);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(140, 28);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.BtnSort_Click);
            // 
            // cmBoxGen
            // 
            this.cmBoxGen.FormattingEnabled = true;
            this.cmBoxGen.Items.AddRange(new object[] {
            "Random values",
            "Almost sorted",
            "Many equals",
            "Reverse order"});
            this.cmBoxGen.Location = new System.Drawing.Point(1067, 15);
            this.cmBoxGen.Margin = new System.Windows.Forms.Padding(4);
            this.cmBoxGen.Name = "cmBoxGen";
            this.cmBoxGen.Size = new System.Drawing.Size(144, 24);
            this.cmBoxGen.TabIndex = 4;
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(951, 21);
            this.bLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(107, 17);
            this.bLabel.TabIndex = 6;
            this.bLabel.Text = "Generating way";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(16, 15);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(160, 28);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load assembly";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "dll";
            this.openFileDialog.Filter = "Class libraries|*.dll|All files|*.*";
            this.openFileDialog.Title = "Check a sorting library";
            // 
            // VisualForm
            // 
            this.AcceptButton = this.btnSort;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 741);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.cmBoxGen);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.sizeUpDown);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VisualForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorting in threads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisualForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.NumericUpDown sizeUpDown;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ComboBox cmBoxGen;
        private System.Windows.Forms.Label bLabel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}

