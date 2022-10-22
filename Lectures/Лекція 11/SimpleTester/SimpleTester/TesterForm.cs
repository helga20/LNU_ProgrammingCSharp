using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SimpleTester
{
    public partial class TesterForm : Form
    {
        private GroupBox[] GroupBoxes;
        public TesterForm()
        {
            InitializeComponent();
            GroupBoxes = new GroupBox[] { gbQuestion1, gbQuestion2, gbQuestion3, gbQuestion4, gbQuestion5 };
        }

        private void TesterForm_Load(object sender, EventArgs e)
        {
            // завантаження форми - зручний час для виконання різноманітних налаштувань
            // наприклад, для завантаження з файлів тестів і відповідей
            string[] subjects = TestProvider.LoadTests(@"..\..\Resources\Tests.txt", @"..\..\Resources\Codes.txt");

            cbCourseList.Items.AddRange(subjects);
            tbResult.AppendText(System.DateTime.Now.Date.ToShortDateString());
        }

        // buttonQuit зазначена як CancelButton головної форми
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // самі groupBox'и розтягаються завдяки Anchors, але вони мусять
        // потурбуватися про вкладені компоненти
        // опрацьовувач один на всіх
        private void gbQuestion_SizeChanged(object sender, EventArgs e)
        {
            GroupBox grBox = sender as GroupBox;
            grBox.Controls[0].Left = grBox.ClientSize.Width / 2 + 6;
            grBox.Controls[1].Left = grBox.ClientSize.Width / 2 + 6;
        }

        // користувач вибрав новий предмет - треба оновити тести
        private void cbCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCourseList.SelectedIndex >= 0)
            {
                TestProvider.FillCaptions(cbCourseList.SelectedItem as string, GroupBoxes);
            }
        }

        // кнопка перевірки стає доступною після заповнення останнього поля
        private void tbUnswer5_TextChanged(object sender, EventArgs e)
        {
            buttonCheck.Enabled = true;
        }

        // перевірка відповіді на тест та опублікування результату
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            tbResult.AppendText(TestProvider.CheckUnswer(cbCourseList.SelectedItem as string, GroupBoxes));
            buttonCheck.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Results.txt", tbResult.Text);
            MessageBox.Show("Результати збережено до файла \"Results.txt\"", "Повідомлення",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
