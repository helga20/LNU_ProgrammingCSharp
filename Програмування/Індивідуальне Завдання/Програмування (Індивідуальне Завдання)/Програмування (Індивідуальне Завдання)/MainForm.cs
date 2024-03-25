using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Програмування__Індивідуальне_Завдання_
{
    public partial class MainForm : Form
    {
        private string path;
        public List<Ingredient> data;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AboutAuthorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програму написав Кіс Юрій\nГрупа ПМі-23", "Про автора");
        }

        private void ViewHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вкладка File:\n" +
                "\tCreate – створити новий кондитерський виріб\n" +
                "\tOpen – відкрити текстовий файл та зчитати дані\n" +
                "\tSave – записати дані з таблиці у відкритий файл\n" +
                "\tSave as… - записати дані з таблиці у новий файл\n" +
                "\tClose - закрити текстовий файл\n" +
                "\tExit – вийти з програми\n" +
                "Вкладка Item:\n" +
                "\tAdd – додати новий інградієнт до кондитерського виробу\n" +
                "\tUpdate – редагувати обраний інградієнт у таблиці\n" +
                "\tDelete – видалити обраний інградієнт у таблиці\n" +
                "Вкладка Help:\n" +
                "\tView help – короткий опис функціоналу програми\n" +
                "\tAbout author - про автора", "Допомога");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Any unsaved data will be deleted", "Exit",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            data = new List<Ingredient>();
            if (MessageBox.Show("This will delete all data in your table", "Create", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                data.Clear();
                PopulateDataGridView(data);

                SaveAsButton.Enabled = true;
                AddButton.Enabled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            datagrid.Rows.Add();

            var opened = new IngredientForm() { Index = datagrid.Rows.Count - 1, data = data };
            opened.ShowDialog(this);

            PopulateDataGridView(data);
        }

        private void PopulateDataGridView(List<Ingredient> toAdd)
        {
            datagrid.Rows.Clear();

            for(int i = 0; i < toAdd.Count; ++i)
                datagrid.Rows.Add(toAdd[i].Name, toAdd[i].Mass, toAdd[i].Calories, toAdd[i].Price);
        }

        private void datagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (datagrid.SelectedRows.Count > 0)
            {
                DeleteButton.Enabled = true;
                UpdateButton.Enabled = true;
            }
            else
            {
                DeleteButton.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete selected row", "Delete",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = 0; i < datagrid.Rows.Count; ++i)
                    if (datagrid.SelectedRows.Contains(datagrid.Rows[i]))
                        data.RemoveAt(i);
                PopulateDataGridView(data);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var opened = new IngredientForm() { Index = datagrid.SelectedRows[0].Index, data = data };
            opened.ShowDialog(this);

            PopulateDataGridView(data);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            data = new List<Ingredient>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var fileContent = string.Empty;

                openFileDialog.InitialDirectory = "C:\\Users\\ulyan\\source\\repos\\Програмування (Індивідуальне Завдання)\\Програмування (Індивідуальне Завдання)\\dat";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    data = JsonConvert.DeserializeObject<List<Ingredient>>(fileContent, new JsonSerializerSettings
                    {
                        Error = delegate (object s, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                        {
                            MessageBox.Show(args.ErrorContext.Error.Message);

                            args.ErrorContext.Handled = true;
                        },
                        Converters = { new IsoDateTimeConverter() }
                    });

                    var toRemove = new List<Ingredient>();
                    foreach (var i in data)
                        if (i.Name == "" || i.Calories <= 0 || i.Mass <= 0 || i.Price <= 0)
                        {
                            MessageBox.Show($"{i.Name} got negative or insufficient values!");
                            toRemove.Add(i);
                        }

                    foreach (var i in toRemove)
                        data.Remove(i);

                    PopulateDataGridView(data);
                }

                YesFile.Text = path.Split('\\')[path.Split('\\').Length - 1];
                AddButton.Enabled = true;
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
                CloseButton.Enabled = true;
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saving = new SaveFileDialog();

            saving.Filter = "All files (*.*)|*.*";
            saving.RestoreDirectory = true;

            if (saving.ShowDialog() == DialogResult.OK)
                using (StreamWriter reader = new StreamWriter(saving.FileName))
                    reader.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            path = "";
            YesFile.Text = "none";
            SaveButton.Enabled = false;
            CloseButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter reader = new StreamWriter(path))
                reader.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        private void firstFeature_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                var sel = from ingr in data
                          where ingr.Calories < 250
                          select ingr;

                List<Ingredient> temp = new List<Ingredient>();
                foreach (var s in sel)
                    temp.Add(s);

                PopulateDataGridView(temp);

                goBack.Enabled = true;
            }
        }

        private void secondFeature_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                var sel = from ingr in data
                          where ingr.Mass * ingr.Price <= 1000
                          select ingr;

                List<Ingredient> temp = new List<Ingredient>();
                foreach (var s in sel)
                    temp.Add(s);

                PopulateDataGridView(temp);

                goBack.Enabled = true;
            }
        }

        private void thirdFeature_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                var sel = from ingr in data
                          where ingr.Mass <= (double)massData.Value
                          select ingr;

                foreach (var s in sel)
                    s.Price *= 0.5;

                PopulateDataGridView(data);
            }
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            PopulateDataGridView(data);
            goBack.Enabled = false;
        }
    }
}