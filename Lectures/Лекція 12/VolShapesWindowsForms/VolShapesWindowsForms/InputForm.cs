using System;
using System.Windows.Forms;

namespace VolShapesWindowsForms
{
    // Форма для введення параметрів нової об'ємної фігури. Головний
    // результат - новостворений об'єкт - потрапляє в поле NewShape.
    //
    // Основним компонентом інтерфейсу є TabControl. Головна його зручність
    // у тому, що для кожного типу фігури є окрема сторінка зі своїм наборром
    // візуальних елементів. Водночас, це й основний недолік: значна кількість
    // написів і рядків уведення дублюються на кожній сторінці. Такі елементи
    // заради простоти використовують спільніобробітники подій. У майбутньому
    // можна було б залишити одну сторінку і замість TabControl використати 
    // групу RadioButton або спадний список.
    // 
    // Уведений текст розпізнаємо при опрацюванні події Leave. Це не дуже надійно,
    // оскільки TextBox'и і кнопки завершення розташовано в різних контейнерах, і
    // подія може не настати для останнього TextBox.

    public partial class InputForm : Form
    {
        public VolShape NewShape;
        private double h;
        private double a;
        private double b;
        private double g;

        public InputForm()
        {
            InitializeComponent();
        }

        private double Parse(TextBox box)
        {
            try
            {
                return double.Parse(box.Text);
            }
            catch (Exception)
            {
                box.Focus();
                return 0.0;
            }
        }
        // тип фігури залежить від обраної сторінки
        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            switch (tabControl.SelectedIndex)
            {
                case 0: NewShape = new Cylinder(a, h); break;
                case 1: NewShape = new Parallele(a, b, h); break;
                case 2: NewShape = new TriPrism(a, b, g, h); break;
                case 3: NewShape = new Cone(a, h); break;
                case 4: NewShape = new RectPiramid(a, b, h); break;
                case 5: NewShape = new TriPiramid(a, b, g, h); break;
                default: NewShape = null; break;
            }
        }

        private void highTextBox_Leave(object sender, EventArgs e)
        {
            h = Parse(sender as TextBox);
        }

        private void aTextBox_Leave(object sender, EventArgs e)
        {
            a = Parse(sender as TextBox);
        }

        private void bTextBox_Leave(object sender, EventArgs e)
        {
            b = Parse(sender as TextBox);
        }

        private void gTextBox_Leave(object sender, EventArgs e)
        {
            g = Parse(sender as TextBox);
        }
    }
}
