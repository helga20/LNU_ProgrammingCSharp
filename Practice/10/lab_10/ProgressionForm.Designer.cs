namespace lab_10
{
    partial class ProgressionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressionForm));
            this.type_progression = new System.Windows.Forms.Label();
            this.first_member = new System.Windows.Forms.Label();
            this.first_member_textBox = new System.Windows.Forms.TextBox();
            this.d_or_q = new System.Windows.Forms.Label();
            this.d_or_q_textBox = new System.Windows.Forms.TextBox();
            this.add_progression = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.clean = new System.Windows.Forms.Button();
            this.addInFile = new System.Windows.Forms.Button();
            this.addInFilrLabel = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Button();
            this.datas = new System.Windows.Forms.Label();
            this.printFromFile = new System.Windows.Forms.Button();
            this.max_sum = new System.Windows.Forms.Button();
            this.max_sum_label = new System.Windows.Forms.Label();
            this.type_progr_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // type_progression
            // 
            this.type_progression.AutoSize = true;
            this.type_progression.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.type_progression.ForeColor = System.Drawing.Color.White;
            this.type_progression.Location = new System.Drawing.Point(42, 21);
            this.type_progression.Name = "type_progression";
            this.type_progression.Size = new System.Drawing.Size(136, 33);
            this.type_progression.TabIndex = 0;
            this.type_progression.Text = "Вид прогресії";
            // 
            // first_member
            // 
            this.first_member.AutoSize = true;
            this.first_member.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold);
            this.first_member.ForeColor = System.Drawing.Color.White;
            this.first_member.Location = new System.Drawing.Point(4, 84);
            this.first_member.Name = "first_member";
            this.first_member.Size = new System.Drawing.Size(219, 33);
            this.first_member.TabIndex = 2;
            this.first_member.Text = "Перший член прогресії";
            // 
            // first_member_textBox
            // 
            this.first_member_textBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.first_member_textBox.Location = new System.Drawing.Point(246, 84);
            this.first_member_textBox.Name = "first_member_textBox";
            this.first_member_textBox.Size = new System.Drawing.Size(153, 33);
            this.first_member_textBox.TabIndex = 3;
            // 
            // d_or_q
            // 
            this.d_or_q.AutoSize = true;
            this.d_or_q.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold);
            this.d_or_q.ForeColor = System.Drawing.Color.White;
            this.d_or_q.Location = new System.Drawing.Point(85, 152);
            this.d_or_q.Name = "d_or_q";
            this.d_or_q.Size = new System.Drawing.Size(44, 33);
            this.d_or_q.TabIndex = 6;
            this.d_or_q.Text = "d/q";
            // 
            // d_or_q_textBox
            // 
            this.d_or_q_textBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.d_or_q_textBox.Location = new System.Drawing.Point(246, 152);
            this.d_or_q_textBox.Name = "d_or_q_textBox";
            this.d_or_q_textBox.Size = new System.Drawing.Size(153, 33);
            this.d_or_q_textBox.TabIndex = 5;
            // 
            // add_progression
            // 
            this.add_progression.BackColor = System.Drawing.Color.PapayaWhip;
            this.add_progression.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.add_progression.ForeColor = System.Drawing.Color.DarkGreen;
            this.add_progression.Location = new System.Drawing.Point(551, 17);
            this.add_progression.Name = "add_progression";
            this.add_progression.Size = new System.Drawing.Size(176, 54);
            this.add_progression.TabIndex = 7;
            this.add_progression.Text = "Додати прогресію";
            this.add_progression.UseVisualStyleBackColor = false;
            this.add_progression.Click += new System.EventHandler(this.add_progression_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold);
            this.info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.info.Location = new System.Drawing.Point(746, -6);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 33);
            this.info.TabIndex = 8;
            // 
            // clean
            // 
            this.clean.BackColor = System.Drawing.Color.PowderBlue;
            this.clean.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.clean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clean.Location = new System.Drawing.Point(578, 103);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(123, 41);
            this.clean.TabIndex = 9;
            this.clean.Text = "Очистити";
            this.clean.UseVisualStyleBackColor = false;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // addInFile
            // 
            this.addInFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addInFile.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.addInFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.addInFile.Location = new System.Drawing.Point(23, 209);
            this.addInFile.Name = "addInFile";
            this.addInFile.Size = new System.Drawing.Size(176, 63);
            this.addInFile.TabIndex = 10;
            this.addInFile.Text = "Додати прогресію у контейнер";
            this.addInFile.UseVisualStyleBackColor = false;
            this.addInFile.Click += new System.EventHandler(this.addInFile_Click);
            // 
            // addInFilrLabel
            // 
            this.addInFilrLabel.AutoSize = true;
            this.addInFilrLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold);
            this.addInFilrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.addInFilrLabel.Location = new System.Drawing.Point(237, 222);
            this.addInFilrLabel.Name = "addInFilrLabel";
            this.addInFilrLabel.Size = new System.Drawing.Size(0, 33);
            this.addInFilrLabel.TabIndex = 11;
            // 
            // print
            // 
            this.print.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.print.Location = new System.Drawing.Point(23, 324);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(176, 64);
            this.print.TabIndex = 12;
            this.print.Text = "Надрукувати контейнер";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // datas
            // 
            this.datas.AutoSize = true;
            this.datas.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datas.Location = new System.Drawing.Point(243, 324);
            this.datas.Name = "datas";
            this.datas.Size = new System.Drawing.Size(0, 18);
            this.datas.TabIndex = 13;
            // 
            // printFromFile
            // 
            this.printFromFile.BackColor = System.Drawing.Color.PaleTurquoise;
            this.printFromFile.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.printFromFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.printFromFile.Location = new System.Drawing.Point(551, 179);
            this.printFromFile.Name = "printFromFile";
            this.printFromFile.Size = new System.Drawing.Size(176, 63);
            this.printFromFile.TabIndex = 14;
            this.printFromFile.Text = "Надрукувати з файлу";
            this.printFromFile.UseVisualStyleBackColor = false;
            this.printFromFile.Click += new System.EventHandler(this.printFromFile_Click);
            // 
            // max_sum
            // 
            this.max_sum.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.max_sum.Location = new System.Drawing.Point(551, 304);
            this.max_sum.Name = "max_sum";
            this.max_sum.Size = new System.Drawing.Size(105, 54);
            this.max_sum.TabIndex = 15;
            this.max_sum.Text = "Найбільша сума";
            this.max_sum.UseVisualStyleBackColor = true;
            this.max_sum.Click += new System.EventHandler(this.max_sum_Click);
            // 
            // max_sum_label
            // 
            this.max_sum_label.AutoSize = true;
            this.max_sum_label.Location = new System.Drawing.Point(551, 369);
            this.max_sum_label.Name = "max_sum_label";
            this.max_sum_label.Size = new System.Drawing.Size(0, 13);
            this.max_sum_label.TabIndex = 16;
            // 
            // type_progr_comboBox
            // 
            this.type_progr_comboBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F);
            this.type_progr_comboBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.type_progr_comboBox.FormattingEnabled = true;
            this.type_progr_comboBox.Items.AddRange(new object[] {
            "арифметична",
            "геометрична"});
            this.type_progr_comboBox.Location = new System.Drawing.Point(246, 21);
            this.type_progr_comboBox.Name = "type_progr_comboBox";
            this.type_progr_comboBox.Size = new System.Drawing.Size(153, 33);
            this.type_progr_comboBox.TabIndex = 17;
            // 
            // ProgressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(926, 529);
            this.Controls.Add(this.type_progr_comboBox);
            this.Controls.Add(this.max_sum_label);
            this.Controls.Add(this.max_sum);
            this.Controls.Add(this.printFromFile);
            this.Controls.Add(this.datas);
            this.Controls.Add(this.print);
            this.Controls.Add(this.addInFilrLabel);
            this.Controls.Add(this.addInFile);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.info);
            this.Controls.Add(this.add_progression);
            this.Controls.Add(this.d_or_q);
            this.Controls.Add(this.d_or_q_textBox);
            this.Controls.Add(this.first_member_textBox);
            this.Controls.Add(this.first_member);
            this.Controls.Add(this.type_progression);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgressionForm";
            this.Text = "Прогресія";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label type_progression;
        private System.Windows.Forms.Label first_member;
        private System.Windows.Forms.TextBox first_member_textBox;
        private System.Windows.Forms.Label d_or_q;
        private System.Windows.Forms.TextBox d_or_q_textBox;
        private System.Windows.Forms.Button add_progression;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button addInFile;
        private System.Windows.Forms.Label addInFilrLabel;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Label datas;
        private System.Windows.Forms.Button printFromFile;
        private System.Windows.Forms.Button max_sum;
        private System.Windows.Forms.Label max_sum_label;
        private System.Windows.Forms.ComboBox type_progr_comboBox;
    }
}

