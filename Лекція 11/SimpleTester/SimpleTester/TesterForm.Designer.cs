namespace SimpleTester
{
    partial class TesterForm
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
            this.labelGet = new System.Windows.Forms.Label();
            this.cbCourseList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbQuestion1 = new System.Windows.Forms.GroupBox();
            this.rbUnswer14 = new System.Windows.Forms.RadioButton();
            this.rbUnswer13 = new System.Windows.Forms.RadioButton();
            this.rbUnswer12 = new System.Windows.Forms.RadioButton();
            this.rbUnswer11 = new System.Windows.Forms.RadioButton();
            this.gbQuestion2 = new System.Windows.Forms.GroupBox();
            this.rbUnswer24 = new System.Windows.Forms.RadioButton();
            this.rbUnswer23 = new System.Windows.Forms.RadioButton();
            this.rbUnswer22 = new System.Windows.Forms.RadioButton();
            this.rbUnswer21 = new System.Windows.Forms.RadioButton();
            this.gbQuestion3 = new System.Windows.Forms.GroupBox();
            this.chbUnswer34 = new System.Windows.Forms.CheckBox();
            this.chbUnswer33 = new System.Windows.Forms.CheckBox();
            this.chbUnswer32 = new System.Windows.Forms.CheckBox();
            this.chbUnswer31 = new System.Windows.Forms.CheckBox();
            this.gbQuestion4 = new System.Windows.Forms.GroupBox();
            this.chbUnswer44 = new System.Windows.Forms.CheckBox();
            this.chbUnswer43 = new System.Windows.Forms.CheckBox();
            this.chbUnswer42 = new System.Windows.Forms.CheckBox();
            this.chbUnswer41 = new System.Windows.Forms.CheckBox();
            this.gbQuestion5 = new System.Windows.Forms.GroupBox();
            this.tbUnswer5 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.gbQuestion1.SuspendLayout();
            this.gbQuestion2.SuspendLayout();
            this.gbQuestion3.SuspendLayout();
            this.gbQuestion4.SuspendLayout();
            this.gbQuestion5.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGet
            // 
            this.labelGet.AutoSize = true;
            this.labelGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGet.Location = new System.Drawing.Point(28, 16);
            this.labelGet.Name = "labelGet";
            this.labelGet.Size = new System.Drawing.Size(148, 20);
            this.labelGet.TabIndex = 0;
            this.labelGet.Text = "Виберіть предмет";
            // 
            // cbCourseList
            // 
            this.cbCourseList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCourseList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCourseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCourseList.Location = new System.Drawing.Point(196, 13);
            this.cbCourseList.Name = "cbCourseList";
            this.cbCourseList.Size = new System.Drawing.Size(237, 28);
            this.cbCourseList.TabIndex = 1;
            this.cbCourseList.Text = "  ?  ";
            this.cbCourseList.SelectedIndexChanged += new System.EventHandler(this.cbCourseList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(10, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 5);
            this.panel1.TabIndex = 2;
            // 
            // gbQuestion1
            // 
            this.gbQuestion1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuestion1.Controls.Add(this.rbUnswer14);
            this.gbQuestion1.Controls.Add(this.rbUnswer13);
            this.gbQuestion1.Controls.Add(this.rbUnswer12);
            this.gbQuestion1.Controls.Add(this.rbUnswer11);
            this.gbQuestion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestion1.Location = new System.Drawing.Point(12, 60);
            this.gbQuestion1.Name = "gbQuestion1";
            this.gbQuestion1.Size = new System.Drawing.Size(858, 85);
            this.gbQuestion1.TabIndex = 3;
            this.gbQuestion1.TabStop = false;
            this.gbQuestion1.Text = " Запитання 1 (5) ";
            this.gbQuestion1.SizeChanged += new System.EventHandler(this.gbQuestion_SizeChanged);
            // 
            // rbUnswer14
            // 
            this.rbUnswer14.AutoSize = true;
            this.rbUnswer14.Location = new System.Drawing.Point(435, 55);
            this.rbUnswer14.Name = "rbUnswer14";
            this.rbUnswer14.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer14.TabIndex = 3;
            this.rbUnswer14.Text = "Відповідь 4";
            this.rbUnswer14.UseVisualStyleBackColor = true;
            // 
            // rbUnswer13
            // 
            this.rbUnswer13.AutoSize = true;
            this.rbUnswer13.Location = new System.Drawing.Point(435, 25);
            this.rbUnswer13.Name = "rbUnswer13";
            this.rbUnswer13.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer13.TabIndex = 2;
            this.rbUnswer13.Text = "Відповідь 3";
            this.rbUnswer13.UseVisualStyleBackColor = true;
            // 
            // rbUnswer12
            // 
            this.rbUnswer12.AutoSize = true;
            this.rbUnswer12.Location = new System.Drawing.Point(6, 55);
            this.rbUnswer12.Name = "rbUnswer12";
            this.rbUnswer12.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer12.TabIndex = 1;
            this.rbUnswer12.Text = "Відповідь 2";
            this.rbUnswer12.UseVisualStyleBackColor = true;
            // 
            // rbUnswer11
            // 
            this.rbUnswer11.AutoSize = true;
            this.rbUnswer11.Location = new System.Drawing.Point(6, 25);
            this.rbUnswer11.Name = "rbUnswer11";
            this.rbUnswer11.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer11.TabIndex = 0;
            this.rbUnswer11.Text = "Відповідь 1";
            this.rbUnswer11.UseVisualStyleBackColor = true;
            // 
            // gbQuestion2
            // 
            this.gbQuestion2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuestion2.Controls.Add(this.rbUnswer24);
            this.gbQuestion2.Controls.Add(this.rbUnswer23);
            this.gbQuestion2.Controls.Add(this.rbUnswer22);
            this.gbQuestion2.Controls.Add(this.rbUnswer21);
            this.gbQuestion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestion2.Location = new System.Drawing.Point(12, 151);
            this.gbQuestion2.Name = "gbQuestion2";
            this.gbQuestion2.Size = new System.Drawing.Size(858, 85);
            this.gbQuestion2.TabIndex = 4;
            this.gbQuestion2.TabStop = false;
            this.gbQuestion2.Text = " Запитання 2 (5) ";
            this.gbQuestion2.SizeChanged += new System.EventHandler(this.gbQuestion_SizeChanged);
            // 
            // rbUnswer24
            // 
            this.rbUnswer24.AutoSize = true;
            this.rbUnswer24.Location = new System.Drawing.Point(435, 55);
            this.rbUnswer24.Name = "rbUnswer24";
            this.rbUnswer24.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer24.TabIndex = 3;
            this.rbUnswer24.TabStop = true;
            this.rbUnswer24.Text = "Відповідь 4";
            this.rbUnswer24.UseVisualStyleBackColor = true;
            // 
            // rbUnswer23
            // 
            this.rbUnswer23.AutoSize = true;
            this.rbUnswer23.Location = new System.Drawing.Point(435, 25);
            this.rbUnswer23.Name = "rbUnswer23";
            this.rbUnswer23.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer23.TabIndex = 2;
            this.rbUnswer23.TabStop = true;
            this.rbUnswer23.Text = "Відповідь 3";
            this.rbUnswer23.UseVisualStyleBackColor = true;
            // 
            // rbUnswer22
            // 
            this.rbUnswer22.AutoSize = true;
            this.rbUnswer22.Location = new System.Drawing.Point(6, 55);
            this.rbUnswer22.Name = "rbUnswer22";
            this.rbUnswer22.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer22.TabIndex = 1;
            this.rbUnswer22.TabStop = true;
            this.rbUnswer22.Text = "Відповідь 2";
            this.rbUnswer22.UseVisualStyleBackColor = true;
            // 
            // rbUnswer21
            // 
            this.rbUnswer21.AutoSize = true;
            this.rbUnswer21.Location = new System.Drawing.Point(6, 25);
            this.rbUnswer21.Name = "rbUnswer21";
            this.rbUnswer21.Size = new System.Drawing.Size(115, 24);
            this.rbUnswer21.TabIndex = 0;
            this.rbUnswer21.TabStop = true;
            this.rbUnswer21.Text = "Відповідь 1";
            this.rbUnswer21.UseVisualStyleBackColor = true;
            // 
            // gbQuestion3
            // 
            this.gbQuestion3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuestion3.Controls.Add(this.chbUnswer34);
            this.gbQuestion3.Controls.Add(this.chbUnswer33);
            this.gbQuestion3.Controls.Add(this.chbUnswer32);
            this.gbQuestion3.Controls.Add(this.chbUnswer31);
            this.gbQuestion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestion3.Location = new System.Drawing.Point(12, 242);
            this.gbQuestion3.Name = "gbQuestion3";
            this.gbQuestion3.Size = new System.Drawing.Size(858, 85);
            this.gbQuestion3.TabIndex = 5;
            this.gbQuestion3.TabStop = false;
            this.gbQuestion3.Text = " Запитання 3 (10) ";
            this.gbQuestion3.SizeChanged += new System.EventHandler(this.gbQuestion_SizeChanged);
            // 
            // chbUnswer34
            // 
            this.chbUnswer34.AutoSize = true;
            this.chbUnswer34.Location = new System.Drawing.Point(435, 55);
            this.chbUnswer34.Name = "chbUnswer34";
            this.chbUnswer34.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer34.TabIndex = 3;
            this.chbUnswer34.Text = "Відповідь 4";
            this.chbUnswer34.UseVisualStyleBackColor = true;
            // 
            // chbUnswer33
            // 
            this.chbUnswer33.AutoSize = true;
            this.chbUnswer33.Location = new System.Drawing.Point(435, 25);
            this.chbUnswer33.Name = "chbUnswer33";
            this.chbUnswer33.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer33.TabIndex = 2;
            this.chbUnswer33.Text = "Відповідь 3";
            this.chbUnswer33.UseVisualStyleBackColor = true;
            // 
            // chbUnswer32
            // 
            this.chbUnswer32.AutoSize = true;
            this.chbUnswer32.Location = new System.Drawing.Point(6, 55);
            this.chbUnswer32.Name = "chbUnswer32";
            this.chbUnswer32.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer32.TabIndex = 1;
            this.chbUnswer32.Text = "Відповідь 2";
            this.chbUnswer32.UseVisualStyleBackColor = true;
            // 
            // chbUnswer31
            // 
            this.chbUnswer31.AutoSize = true;
            this.chbUnswer31.Location = new System.Drawing.Point(6, 25);
            this.chbUnswer31.Name = "chbUnswer31";
            this.chbUnswer31.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer31.TabIndex = 0;
            this.chbUnswer31.Text = "Відповідь 1";
            this.chbUnswer31.UseVisualStyleBackColor = true;
            // 
            // gbQuestion4
            // 
            this.gbQuestion4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuestion4.Controls.Add(this.chbUnswer44);
            this.gbQuestion4.Controls.Add(this.chbUnswer43);
            this.gbQuestion4.Controls.Add(this.chbUnswer42);
            this.gbQuestion4.Controls.Add(this.chbUnswer41);
            this.gbQuestion4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestion4.Location = new System.Drawing.Point(10, 333);
            this.gbQuestion4.Name = "gbQuestion4";
            this.gbQuestion4.Size = new System.Drawing.Size(858, 85);
            this.gbQuestion4.TabIndex = 6;
            this.gbQuestion4.TabStop = false;
            this.gbQuestion4.Text = " Запитання 4 (10) ";
            this.gbQuestion4.SizeChanged += new System.EventHandler(this.gbQuestion_SizeChanged);
            // 
            // chbUnswer44
            // 
            this.chbUnswer44.AutoSize = true;
            this.chbUnswer44.Location = new System.Drawing.Point(435, 55);
            this.chbUnswer44.Name = "chbUnswer44";
            this.chbUnswer44.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer44.TabIndex = 3;
            this.chbUnswer44.Text = "Відповідь 4";
            this.chbUnswer44.UseVisualStyleBackColor = true;
            // 
            // chbUnswer43
            // 
            this.chbUnswer43.AutoSize = true;
            this.chbUnswer43.Location = new System.Drawing.Point(435, 25);
            this.chbUnswer43.Name = "chbUnswer43";
            this.chbUnswer43.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer43.TabIndex = 2;
            this.chbUnswer43.Text = "Відповідь 3";
            this.chbUnswer43.UseVisualStyleBackColor = true;
            // 
            // chbUnswer42
            // 
            this.chbUnswer42.AutoSize = true;
            this.chbUnswer42.Location = new System.Drawing.Point(6, 55);
            this.chbUnswer42.Name = "chbUnswer42";
            this.chbUnswer42.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer42.TabIndex = 1;
            this.chbUnswer42.Text = "Відповідь 2";
            this.chbUnswer42.UseVisualStyleBackColor = true;
            // 
            // chbUnswer41
            // 
            this.chbUnswer41.AutoSize = true;
            this.chbUnswer41.Location = new System.Drawing.Point(6, 25);
            this.chbUnswer41.Name = "chbUnswer41";
            this.chbUnswer41.Size = new System.Drawing.Size(116, 24);
            this.chbUnswer41.TabIndex = 0;
            this.chbUnswer41.Text = "Відповідь 1";
            this.chbUnswer41.UseVisualStyleBackColor = true;
            // 
            // gbQuestion5
            // 
            this.gbQuestion5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuestion5.Controls.Add(this.tbUnswer5);
            this.gbQuestion5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestion5.Location = new System.Drawing.Point(10, 424);
            this.gbQuestion5.Name = "gbQuestion5";
            this.gbQuestion5.Size = new System.Drawing.Size(858, 61);
            this.gbQuestion5.TabIndex = 7;
            this.gbQuestion5.TabStop = false;
            this.gbQuestion5.Text = " Запитання 5 (20) ";
            // 
            // tbUnswer5
            // 
            this.tbUnswer5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnswer5.Location = new System.Drawing.Point(154, 25);
            this.tbUnswer5.Name = "tbUnswer5";
            this.tbUnswer5.Size = new System.Drawing.Size(689, 26);
            this.tbUnswer5.TabIndex = 0;
            this.tbUnswer5.TextChanged += new System.EventHandler(this.tbUnswer5_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(8, 491);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 5);
            this.panel2.TabIndex = 8;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Enabled = false;
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCheck.Location = new System.Drawing.Point(458, 12);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(120, 29);
            this.buttonCheck.TabIndex = 9;
            this.buttonCheck.Text = "Перевірити";
            this.buttonCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonQuit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonQuit.Location = new System.Drawing.Point(748, 12);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(120, 29);
            this.buttonQuit.TabIndex = 11;
            this.buttonQuit.Text = "Завершити";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.BackColor = System.Drawing.SystemColors.Control;
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbResult.Location = new System.Drawing.Point(10, 511);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(858, 164);
            this.tbResult.TabIndex = 12;
            this.tbResult.Text = "Результати тестування ";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSave.Location = new System.Drawing.Point(603, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 29);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // TesterForm
            // 
            this.AcceptButton = this.buttonCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(882, 686);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbQuestion5);
            this.Controls.Add(this.gbQuestion4);
            this.Controls.Add(this.gbQuestion3);
            this.Controls.Add(this.gbQuestion2);
            this.Controls.Add(this.gbQuestion1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbCourseList);
            this.Controls.Add(this.labelGet);
            this.MinimumSize = new System.Drawing.Size(890, 650);
            this.Name = "TesterForm";
            this.Text = "Тестування";
            this.Load += new System.EventHandler(this.TesterForm_Load);
            this.gbQuestion1.ResumeLayout(false);
            this.gbQuestion1.PerformLayout();
            this.gbQuestion2.ResumeLayout(false);
            this.gbQuestion2.PerformLayout();
            this.gbQuestion3.ResumeLayout(false);
            this.gbQuestion3.PerformLayout();
            this.gbQuestion4.ResumeLayout(false);
            this.gbQuestion4.PerformLayout();
            this.gbQuestion5.ResumeLayout(false);
            this.gbQuestion5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGet;
        private System.Windows.Forms.ComboBox cbCourseList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbQuestion1;
        private System.Windows.Forms.RadioButton rbUnswer11;
        private System.Windows.Forms.RadioButton rbUnswer14;
        private System.Windows.Forms.RadioButton rbUnswer13;
        private System.Windows.Forms.RadioButton rbUnswer12;
        private System.Windows.Forms.GroupBox gbQuestion2;
        private System.Windows.Forms.RadioButton rbUnswer24;
        private System.Windows.Forms.RadioButton rbUnswer23;
        private System.Windows.Forms.RadioButton rbUnswer22;
        private System.Windows.Forms.RadioButton rbUnswer21;
        private System.Windows.Forms.GroupBox gbQuestion3;
        private System.Windows.Forms.CheckBox chbUnswer34;
        private System.Windows.Forms.CheckBox chbUnswer33;
        private System.Windows.Forms.CheckBox chbUnswer32;
        private System.Windows.Forms.CheckBox chbUnswer31;
        private System.Windows.Forms.GroupBox gbQuestion4;
        private System.Windows.Forms.CheckBox chbUnswer44;
        private System.Windows.Forms.CheckBox chbUnswer43;
        private System.Windows.Forms.CheckBox chbUnswer42;
        private System.Windows.Forms.CheckBox chbUnswer41;
        private System.Windows.Forms.GroupBox gbQuestion5;
        private System.Windows.Forms.TextBox tbUnswer5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button buttonSave;
    }
}

