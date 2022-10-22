using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace NotepadCSharp
{
	/// <summary>
	/// Summary description for blank.
	/// </summary>
	public class blank : System.Windows.Forms.Form
	{
		public System.Windows.Forms.RichTextBox richTextBox1;
		public string DocName = "";
		private string BufferText = "";
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem cmnuCut;
		private System.Windows.Forms.MenuItem cmnuCopy;
		private System.Windows.Forms.MenuItem cmnuPaste;
		private System.Windows.Forms.MenuItem cmnuDelete;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem cmnuSelectAll;
		public bool IsSaved = false;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel sbAmount;
		private System.Windows.Forms.StatusBarPanel sbTime;
		private System.Windows.Forms.MainMenu mainMenu1;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;



		public blank()
		{
			
			InitializeComponent();
			//�������� Text ������ sbTime ������������� ��������� �����, 
			// ������������� ��� � ��� String
			sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
			//� ������ ����������� ���������  ������� ������� ����
			sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
		}

		
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.cmnuCut = new System.Windows.Forms.MenuItem();
			this.cmnuCopy = new System.Windows.Forms.MenuItem();
			this.cmnuPaste = new System.Windows.Forms.MenuItem();
			this.cmnuDelete = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.cmnuSelectAll = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.sbAmount = new System.Windows.Forms.StatusBarPanel();
			this.sbTime = new System.Windows.Forms.StatusBarPanel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			((System.ComponentModel.ISupportInitialize)(this.sbAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbTime)).BeginInit();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.ContextMenu = this.contextMenu1;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(292, 244);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
		
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.cmnuCut,
																						 this.cmnuCopy,
																						 this.cmnuPaste,
																						 this.cmnuDelete,
																						 this.menuItem6,
																						 this.cmnuSelectAll});
			// 
			// cmnuCut
			// 
			this.cmnuCut.Index = 0;
			this.cmnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.cmnuCut.Text = "Cu&t";
			this.cmnuCut.Click += new System.EventHandler(this.cmnuCut_Click);
			// 
			// cmnuCopy
			// 
			this.cmnuCopy.Index = 1;
			this.cmnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.cmnuCopy.Text = "&Copy";
			this.cmnuCopy.Click += new System.EventHandler(this.cmnuCopy_Click);
			// 
			// cmnuPaste
			// 
			this.cmnuPaste.Index = 2;
			this.cmnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.cmnuPaste.Text = "&Paste";
			this.cmnuPaste.Click += new System.EventHandler(this.cmnuPaste_Click);
			// 
			// cmnuDelete
			// 
			this.cmnuDelete.Index = 3;
			this.cmnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.cmnuDelete.Text = "&Delete";
			this.cmnuDelete.Click += new System.EventHandler(this.cmnuDelete_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// cmnuSelectAll
			// 
			this.cmnuSelectAll.Index = 5;
			this.cmnuSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.cmnuSelectAll.Text = "Select &All";
			this.cmnuSelectAll.Click += new System.EventHandler(this.cmnuSelectAll_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 244);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbAmount,
																						  this.sbTime});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(292, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// sbAmount
			// 
			this.sbAmount.Text = "Amount of symbols";
			this.sbAmount.Width = 140;
			// 
			// sbTime
			// 
			this.sbTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.sbTime.Text = "Time";
			this.sbTime.Width = 80;
			// 
			// blank
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "blank";
			this.Text = "blank";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.blank_Closing);
			((System.ComponentModel.ISupportInitialize)(this.sbAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbTime)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		// ��������� ������
		public void Cut()
		{
			this.BufferText = richTextBox1.SelectedText;
			richTextBox1.SelectedText = "";
		}

		// ����������� ������
		public void Copy()
		{
			this.BufferText = richTextBox1.SelectedText;
		}

		// �������
		public void Paste()
		{
			richTextBox1.SelectedText = this.BufferText;
		}

		// ��������� ����� ������ - ���������� �������� SelectAll �������� ���������� RichTextBox 
		public void SelectAll()
		{
			richTextBox1.SelectAll(); 
		}

		// ��������.
		public void Delete()
		{
			richTextBox1.SelectedText = "";	
			this.BufferText = "";
		}
		//������� ����� Open, � �������� ��������� ��������� ������ ������  �����.
		public void Open(string OpenFileName)
		{
			//���� ���� �� ������, ������������ ����� (�������� ���������� ��������������)
			if (OpenFileName == "") 
			{
				return;
			}
			else
			{
				//������� ����� ������ StreamReader � �������� ��� ���������� OpenFileName
				StreamReader sr = new StreamReader(OpenFileName);
				//������ ���� ���� � ���������� ��� � richTextBox1
				richTextBox1.Text = sr.ReadToEnd();
				// ��������� �����
				sr.Close();
				//���������� DocName ����������� �������� ������.
				DocName = OpenFileName;
			}			
		}

		private void cmnuCut_Click(object sender, System.EventArgs e)
		{
			Cut();
		}

		private void cmnuCopy_Click(object sender, System.EventArgs e)
		{
			Copy();
		}

		private void cmnuPaste_Click(object sender, System.EventArgs e)
		{
			Paste();
		}

		private void cmnuDelete_Click(object sender, System.EventArgs e)
		{
			Delete();
		}

		private void cmnuSelectAll_Click(object sender, System.EventArgs e)
		{
			SelectAll();
		}
		//������� ����� Save, � �������� ��������� ��������� ������ ������  �����.
		public void Save(string SaveFileName)
		{
			//���� ���� �� ������, ������������ ����� (�������� ���������� ��������������)
			if (SaveFileName == "") 
			{
				return;
			}
			else
			{
				//������� ����� ������ StreamWriter � �������� ��� ���������� OpenFileName
				StreamWriter sw = new StreamWriter(SaveFileName);
				//���������� richTextBox1 ���������� � ����
				sw.WriteLine(richTextBox1.Text);
				//��������� �����
				sw.Close();
				//������������� � �������� ����� ��������� �������� ������������ �����
				DocName = SaveFileName;
			}
		}

		private void blank_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//���� ���������� IsSaved ����� �������� true, �. � �������� ����� �������� 
			//��� �������� (Save As) ��� � �������� ��������� ���� ��������� ��������� (Save) �� ����������� �������
			if(IsSaved ==true)
				//���������� ���������� ����, ������������ ��������� ��������.
				if	(MessageBox.Show("Do you want save changes in " + this.DocName + "?", 
					"Message", MessageBoxButtons.YesNo, 
					MessageBoxIcon.Question) == DialogResult.Yes)
					//���� ���� ������  ������ Yes, �������� ����� Save
				{
					this.Save(this.DocName); 
				}		
		 
		
		}

		private void richTextBox1_TextChanged(object sender, System.EventArgs e)
		{
			//�������� Text ������ sbAmount ������������� ������� "�mount of symbols " 
			//� �����  ������ � RichTextBox.
			sbAmount.Text = "�mount of symbols " + richTextBox1.Text.Length.ToString(); 
		}			
		

		}
	}

