using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace VolShapesWindowsForms
{
    // Клас містить методи взаємодії з GUI. Оскільки вікно "кнопкове", то
    // тут найбільше методів опрацювання button_Click. Замість кнопок можна
    // було б використати меню (без зміни самих методів).
    // Результати програма виводить здебільшого в MessageBox, що не дуже зручно,
    // оскільки нема можливості зберігати їх. Доречно було б доповнити вікно
    // багаторядковим TextBox для ведення журналу виконаних операцій.
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // Завершення роботи програми
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Викликає створення та відображає колекцію об'єктів "за замовчуванням"
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            Procedures.CreateDefaultShapes();
            this.listOfShapes.DataSource = Procedures.Shapes;
        }
        // Пошук фігури найбільшого об'єму виконано безпосередньо тут
        // завдяки використанню методу розширення списку та завдяки тому,
        // що фігури реалізують IComparable
        // Результати виведено в панель діалогу.
        private void buttonMax_Click(object sender, EventArgs e)
        {
            if (Procedures.Shapes.Count > 0)
                MessageBox.Show($"Найбільшою є\n  {Procedures.Shapes.Max()}",
                    "Фігура з найбільшим об'ємом",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Неможливо шукати фігуру в попрожньому списку", "Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Вилучення обраної фігури вимагає підтвердження користувача.
        // Фігуру вилучають з моделі та оновлюють відображення.
        // Фігуру обрано, якщо listBox.SelectedIndex >= 0,
        // яку саме - listBox.SelectedItem
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listOfShapes.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Чи справді Ви хочете вилучити фігуру\n  {listOfShapes.SelectedItem}",
                    "Потрібне підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Procedures.Shapes.Remove(listOfShapes.SelectedItem as VolShape);
                    listOfShapes.DataSource = null;
                    listOfShapes.DataSource = Procedures.Shapes;
                }
            }
        }
        // Для обчислення GUI звертається до моделі, результат відображає
        // на діалоговій панелі.
        private void buttonSum_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Сумарний об'єм усіх фігур {Procedures.CalculateSumOfVolumes(), 6:F2}",
                "Результат обчислень",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        // Запускає діалог вибору імені файла для завантаження.
        // Якщо користувач обрав файл, розрізняємо формат файла (розширення)
        // та викоикаємо відповідний метод завантаження
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                if (File.Exists(fileName))
                {
                    try
                    {
                        switch (Path.GetExtension(fileName))
                        {
                            case ".txt": Procedures.LoadFromTextFile(fileName); break;
                            case ".soap": Procedures.LoadFromSoapFile(fileName); break;
                            case ".bin": Procedures.LoadFromBinaryFile(fileName); break;
                            default: MessageBox.Show("Файл невідомого формату", "Помилка імені файла",
                                MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка читання з файла.\n  Ім'я: {openFileDialog.FileName}\n  Помилка: {ex.Message}", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    listOfShapes.DataSource = Procedures.Shapes;
                }
                else MessageBox.Show($"Файл {openFileDialog.FileName} не існує.\nОберіть файл з наявних.",
                    "Помилка імені файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Діалог зберігання можна оформити коротше (без додаткових перевірок).
        // Формат зберігання можна прив'язати до saveFileDialog.FilterIndex замість
        // розширення імені файла
        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1: Procedures.StoreToTextFile(saveFileDialog.FileName); break;
                    case 2: Procedures.StoreToSoapFile(saveFileDialog.FileName); break;
                    case 3: Procedures.StoreToBinaryFile(saveFileDialog.FileName); break;
                }
            }
        }
        // Відкрває дочірню форму для створення нового об'єкта.
        // Післядоповнення моделі оновлюємо відображення.
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.OK && inputForm.NewShape != null)
            {
                Procedures.Shapes.Add(inputForm.NewShape);
                listOfShapes.DataSource = null;
                listOfShapes.DataSource = Procedures.Shapes;
            }
            inputForm.Dispose();
        }
    }
}
