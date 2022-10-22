using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NotepadCSharp
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(312, 104);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Notepad C# 2006 All rights reserved";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(144, 120);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(152, 23);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "www.notepadcsharp.com";
			this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 152);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "&OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 182);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.Text = "About Notepad C#";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_Click(object sender, System.EventArgs e)
		{
		//Добавляем блок для обработки исключений - по разным причинам 
		//пользователь может не получить доступа к ресурсу.
			try
			{
				//Вызываем метод VisitLink, определенный ниже
				VisitLink();
			}
			catch (Exception ex )
			{
				MessageBox.Show(ex +"Unable to open link that was clicked.");
			}
			

		
		}
		//Создаем метод VisitLink
			private void VisitLink()
			{
				// Изменяем цвет посещенной ссылки, программно 
				//обращаясь к свойству LinkVisited элемента LinkLabel 
				linkLabel1.LinkVisited = true;
				//Вызываем метод Process.Start method  для запуска браузера, 
				//установленного по умолчанию и открытия ссылки
				System.Diagnostics.Process.Start("http://www.notepadcsharp.com");
			}

		

		

		}
	}

