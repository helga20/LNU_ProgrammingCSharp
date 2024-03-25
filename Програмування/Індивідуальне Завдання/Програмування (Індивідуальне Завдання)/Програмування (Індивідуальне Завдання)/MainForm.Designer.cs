namespace Програмування__Індивідуальне_Завдання_
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddButton = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewHelpButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAuthorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLabel = new System.Windows.Forms.Label();
            this.YesFile = new System.Windows.Forms.Label();
            this.firstFeature = new System.Windows.Forms.Button();
            this.secondFeature = new System.Windows.Forms.Button();
            this.thirdFeature = new System.Windows.Forms.Button();
            this.thirdFeatureText = new System.Windows.Forms.Label();
            this.massData = new System.Windows.Forms.NumericUpDown();
            this.goBack = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.massData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateButton,
            this.OpenButton,
            this.SaveButton,
            this.SaveAsButton,
            this.CloseButton,
            this.ExitButton});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // CreateButton
            // 
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(185, 34);
            this.CreateButton.Text = "Create";
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(185, 34);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(185, 34);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Enabled = false;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(185, 34);
            this.SaveAsButton.Text = "Save as...";
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Enabled = false;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(185, 34);
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(185, 34);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.UpdateButton,
            this.DeleteButton});
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.itemToolStripMenuItem.Text = "Ingredient";
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(172, 34);
            this.AddButton.Text = "Add";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(172, 34);
            this.UpdateButton.Text = "Update";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(172, 34);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewHelpButton,
            this.AboutAuthorButton});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // ViewHelpButton
            // 
            this.ViewHelpButton.Name = "ViewHelpButton";
            this.ViewHelpButton.Size = new System.Drawing.Size(224, 34);
            this.ViewHelpButton.Text = "View Help";
            this.ViewHelpButton.Click += new System.EventHandler(this.ViewHelpButton_Click);
            // 
            // AboutAuthorButton
            // 
            this.AboutAuthorButton.Name = "AboutAuthorButton";
            this.AboutAuthorButton.Size = new System.Drawing.Size(224, 34);
            this.AboutAuthorButton.Text = "About Author";
            this.AboutAuthorButton.Click += new System.EventHandler(this.AboutAuthorButton_Click);
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.AllowUserToResizeColumns = false;
            this.datagrid.AllowUserToResizeRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.datagrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.datagrid.Location = new System.Drawing.Point(12, 36);
            this.datagrid.MultiSelect = false;
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.RowHeadersWidth = 62;
            this.datagrid.RowTemplate.Height = 28;
            this.datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid.Size = new System.Drawing.Size(980, 616);
            this.datagrid.TabIndex = 1;
            this.datagrid.SelectionChanged += new System.EventHandler(this.datagrid_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Mass";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Calories";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Price";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileLabel.Location = new System.Drawing.Point(998, 597);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(251, 29);
            this.FileLabel.TabIndex = 2;
            this.FileLabel.Text = "Currently opened File:";
            // 
            // YesFile
            // 
            this.YesFile.AutoSize = true;
            this.YesFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesFile.Location = new System.Drawing.Point(998, 626);
            this.YesFile.Name = "YesFile";
            this.YesFile.Size = new System.Drawing.Size(67, 29);
            this.YesFile.TabIndex = 3;
            this.YesFile.Text = "none";
            // 
            // firstFeature
            // 
            this.firstFeature.Location = new System.Drawing.Point(1003, 36);
            this.firstFeature.Name = "firstFeature";
            this.firstFeature.Size = new System.Drawing.Size(246, 70);
            this.firstFeature.TabIndex = 4;
            this.firstFeature.Text = "Обрати малокалорійні інградієнти";
            this.firstFeature.UseVisualStyleBackColor = true;
            this.firstFeature.Click += new System.EventHandler(this.firstFeature_Click);
            // 
            // secondFeature
            // 
            this.secondFeature.Location = new System.Drawing.Point(1003, 112);
            this.secondFeature.Name = "secondFeature";
            this.secondFeature.Size = new System.Drawing.Size(246, 70);
            this.secondFeature.TabIndex = 5;
            this.secondFeature.Text = "Обрати найвигідніші продукти";
            this.secondFeature.UseVisualStyleBackColor = true;
            this.secondFeature.Click += new System.EventHandler(this.secondFeature_Click);
            // 
            // thirdFeature
            // 
            this.thirdFeature.Location = new System.Drawing.Point(1003, 234);
            this.thirdFeature.Name = "thirdFeature";
            this.thirdFeature.Size = new System.Drawing.Size(246, 42);
            this.thirdFeature.TabIndex = 6;
            this.thirdFeature.Text = "50% Знижка для";
            this.thirdFeature.UseVisualStyleBackColor = true;
            this.thirdFeature.Click += new System.EventHandler(this.thirdFeature_Click);
            // 
            // thirdFeatureText
            // 
            this.thirdFeatureText.AutoSize = true;
            this.thirdFeatureText.Location = new System.Drawing.Point(999, 292);
            this.thirdFeatureText.Name = "thirdFeatureText";
            this.thirdFeatureText.Size = new System.Drawing.Size(175, 20);
            this.thirdFeatureText.TabIndex = 7;
            this.thirdFeatureText.Text = "Продуктів з масою до";
            // 
            // massData
            // 
            this.massData.Location = new System.Drawing.Point(1177, 290);
            this.massData.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.massData.Name = "massData";
            this.massData.Size = new System.Drawing.Size(72, 26);
            this.massData.TabIndex = 8;
            // 
            // goBack
            // 
            this.goBack.Enabled = false;
            this.goBack.Location = new System.Drawing.Point(1003, 552);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(246, 42);
            this.goBack.TabIndex = 9;
            this.goBack.Text = "Повернути вибірку";
            this.goBack.UseVisualStyleBackColor = true;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.goBack);
            this.Controls.Add(this.massData);
            this.Controls.Add(this.thirdFeatureText);
            this.Controls.Add(this.thirdFeature);
            this.Controls.Add(this.secondFeature);
            this.Controls.Add(this.firstFeature);
            this.Controls.Add(this.YesFile);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор кондитерських виборів";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.massData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateButton;
        private System.Windows.Forms.ToolStripMenuItem OpenButton;
        private System.Windows.Forms.ToolStripMenuItem SaveButton;
        private System.Windows.Forms.ToolStripMenuItem SaveAsButton;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddButton;
        private System.Windows.Forms.ToolStripMenuItem UpdateButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewHelpButton;
        private System.Windows.Forms.ToolStripMenuItem AboutAuthorButton;
        private System.Windows.Forms.ToolStripMenuItem CloseButton;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Label YesFile;
        private System.Windows.Forms.Button firstFeature;
        private System.Windows.Forms.Button secondFeature;
        private System.Windows.Forms.Button thirdFeature;
        private System.Windows.Forms.Label thirdFeatureText;
        private System.Windows.Forms.NumericUpDown massData;
        private System.Windows.Forms.Button goBack;
    }
}