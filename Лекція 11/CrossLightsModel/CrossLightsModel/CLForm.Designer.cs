namespace CrossLightsModel
{
    partial class CLForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lampsPanel = new System.Windows.Forms.Panel();
            this.manualButton = new System.Windows.Forms.Button();
            this.autoButton = new System.Windows.Forms.Button();
            this.periodGroupBox = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.greenLabel = new System.Windows.Forms.Label();
            this.yellowTextBox = new System.Windows.Forms.TextBox();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.redLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.periodGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lampsPanel
            // 
            this.lampsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lampsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lampsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lampsPanel.Location = new System.Drawing.Point(0, 0);
            this.lampsPanel.Name = "lampsPanel";
            this.lampsPanel.Size = new System.Drawing.Size(186, 450);
            this.lampsPanel.TabIndex = 0;
            this.lampsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lampsPanel_Paint);
            // 
            // manualButton
            // 
            this.manualButton.Location = new System.Drawing.Point(214, 17);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(112, 30);
            this.manualButton.TabIndex = 1;
            this.manualButton.Text = "Ручне";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.Click += new System.EventHandler(this.manualButton_Click);
            // 
            // autoButton
            // 
            this.autoButton.Location = new System.Drawing.Point(214, 53);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(112, 30);
            this.autoButton.TabIndex = 2;
            this.autoButton.Text = "Автомат";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // periodGroupBox
            // 
            this.periodGroupBox.Controls.Add(this.okButton);
            this.periodGroupBox.Controls.Add(this.greenTextBox);
            this.periodGroupBox.Controls.Add(this.greenLabel);
            this.periodGroupBox.Controls.Add(this.yellowTextBox);
            this.periodGroupBox.Controls.Add(this.yellowLabel);
            this.periodGroupBox.Controls.Add(this.redTextBox);
            this.periodGroupBox.Controls.Add(this.redLabel);
            this.periodGroupBox.Location = new System.Drawing.Point(197, 93);
            this.periodGroupBox.Name = "periodGroupBox";
            this.periodGroupBox.Size = new System.Drawing.Size(143, 223);
            this.periodGroupBox.TabIndex = 3;
            this.periodGroupBox.TabStop = false;
            this.periodGroupBox.Text = "Тривалості (c)";
            this.periodGroupBox.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(17, 175);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(112, 30);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Пуск";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // greenTextBox
            // 
            this.greenTextBox.Location = new System.Drawing.Point(53, 140);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(75, 20);
            this.greenTextBox.TabIndex = 2;
            this.greenTextBox.Text = "5";
            this.greenTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(16, 124);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(43, 13);
            this.greenLabel.TabIndex = 5;
            this.greenLabel.Text = "зелене";
            // 
            // yellowTextBox
            // 
            this.yellowTextBox.Location = new System.Drawing.Point(53, 90);
            this.yellowTextBox.Name = "yellowTextBox";
            this.yellowTextBox.Size = new System.Drawing.Size(75, 20);
            this.yellowTextBox.TabIndex = 1;
            this.yellowTextBox.Text = "1";
            this.yellowTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // yellowLabel
            // 
            this.yellowLabel.AutoSize = true;
            this.yellowLabel.Location = new System.Drawing.Point(16, 74);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(38, 13);
            this.yellowLabel.TabIndex = 4;
            this.yellowLabel.Text = "жовте";
            // 
            // redTextBox
            // 
            this.redTextBox.Location = new System.Drawing.Point(53, 40);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(75, 20);
            this.redTextBox.TabIndex = 0;
            this.redTextBox.Text = "5";
            this.redTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(16, 24);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(48, 13);
            this.redLabel.TabIndex = 3;
            this.redLabel.Text = "червоне";
            // 
            // quitButton
            // 
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitButton.Location = new System.Drawing.Point(213, 408);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(112, 30);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Завершити";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CLForm
            // 
            this.AcceptButton = this.manualButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.quitButton;
            this.ClientSize = new System.Drawing.Size(350, 450);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.periodGroupBox);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.manualButton);
            this.Controls.Add(this.lampsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CLForm";
            this.Text = "Модель світлофора";
            this.Load += new System.EventHandler(this.CLForm_Load);
            this.periodGroupBox.ResumeLayout(false);
            this.periodGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lampsPanel;
        private System.Windows.Forms.Button manualButton;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.GroupBox periodGroupBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox greenTextBox;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.TextBox yellowTextBox;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.TextBox redTextBox;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Timer timer;
    }
}

