namespace WindowsFormsDialogs
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
            this.btnStartLoadDialog = new System.Windows.Forms.Button();
            this.btnStartSaveDialog = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tBxDialogResult = new System.Windows.Forms.TextBox();
            this.tBxFileName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tBxContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartLoadDialog
            // 
            this.btnStartLoadDialog.Location = new System.Drawing.Point(18, 18);
            this.btnStartLoadDialog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartLoadDialog.Name = "btnStartLoadDialog";
            this.btnStartLoadDialog.Size = new System.Drawing.Size(112, 35);
            this.btnStartLoadDialog.TabIndex = 0;
            this.btnStartLoadDialog.Text = "Load";
            this.btnStartLoadDialog.UseVisualStyleBackColor = true;
            this.btnStartLoadDialog.Click += new System.EventHandler(this.btnStartLoadDialog_Click);
            // 
            // btnStartSaveDialog
            // 
            this.btnStartSaveDialog.Location = new System.Drawing.Point(140, 18);
            this.btnStartSaveDialog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartSaveDialog.Name = "btnStartSaveDialog";
            this.btnStartSaveDialog.Size = new System.Drawing.Size(112, 35);
            this.btnStartSaveDialog.TabIndex = 1;
            this.btnStartSaveDialog.Text = "Save";
            this.btnStartSaveDialog.UseVisualStyleBackColor = true;
            this.btnStartSaveDialog.Click += new System.EventHandler(this.btnStartSaveDialog_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Text files|*.txt|All files|*.*";
            this.openFileDialog.Title = "Check file to load";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.ValidateNames = false;
            // 
            // tBxDialogResult
            // 
            this.tBxDialogResult.Location = new System.Drawing.Point(18, 63);
            this.tBxDialogResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBxDialogResult.Name = "tBxDialogResult";
            this.tBxDialogResult.Size = new System.Drawing.Size(232, 26);
            this.tBxDialogResult.TabIndex = 2;
            // 
            // tBxFileName
            // 
            this.tBxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBxFileName.Location = new System.Drawing.Point(18, 103);
            this.tBxFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBxFileName.Name = "tBxFileName";
            this.tBxFileName.Size = new System.Drawing.Size(400, 26);
            this.tBxFileName.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(261, 18);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 35);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tBxContent
            // 
            this.tBxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBxContent.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBxContent.Location = new System.Drawing.Point(18, 143);
            this.tBxContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBxContent.Multiline = true;
            this.tBxContent.Name = "tBxContent";
            this.tBxContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBxContent.Size = new System.Drawing.Size(400, 256);
            this.tBxContent.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 420);
            this.Controls.Add(this.tBxContent);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tBxFileName);
            this.Controls.Add(this.tBxDialogResult);
            this.Controls.Add(this.btnStartSaveDialog);
            this.Controls.Add(this.btnStartLoadDialog);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Test File Dialogs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartLoadDialog;
        private System.Windows.Forms.Button btnStartSaveDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox tBxDialogResult;
        private System.Windows.Forms.TextBox tBxFileName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tBxContent;
    }
}

