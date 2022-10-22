using System;
using System.Drawing;
using System.Windows.Forms;
using TaskWorker;

namespace ArrayView
{
    public partial class ArrayView : UserControl
    {
        private InTaskSorter sorter;      // * зв'язок з контроллером потрібен, щоб його можна було зупинити або замінити
                                          //   заміну виконують вибором у комбобоксі; вона означає зміну алгоритму сортування
                                          //   Постачальником сортерів є контроллер, він же зберігає колекцію сортерів, щоб
                                          //   запускати їх на виконання
        private int[] arrayToShow;        // * сортований-мальований масив; може змінюватися (значення і/або розмір)
                                          //   незалежно від інших частин компоненти. Постачальником масивів є модель,
                                          //   зберігають масиви тільки тут
        // objects serve graphical needs
        private readonly Graphics canvas;          // * об'єкти, що обслуговують 
        private readonly Pen erasePen;             // *    графіку

        public ArrayView()
        {
            InitializeComponent();
            // the view can exist alone without of a controller
            // reference to the controller will be set later
            this.sorter = null;      // * view може існувати і без controller, і без масиву
            this.arrayToShow = null; // * зв'язок з ними встановлюють згодом
            this.canvas = viewPanel.CreateGraphics();
            this.erasePen = new Pen(SystemColors.Control);
        }
        // конструктор з параметрами зручно використати для програмного створення компоненти
        public ArrayView(Point location, int[] array) : this()
        {
            this.Location = location;
            this.arrayToShow = array;
        }
        // usual methods and properties of the visual component
        // * звичайні методи і властивості візуальної компоненти
        public void Add(string s)
        {
            this.cmbMethods.Items.Add(s);
        }
        public void AddRange(string[] ss)
        {
            this.cmbMethods.Items.AddRange(ss);
        }
        public bool ButtonIsVisible
        {
            get
            {
                return viewButton.Visible;
            }
            set
            {
                viewButton.Visible = value;
            }
        }
        public bool ButtonIsEnabled
        {
            get
            {
                return viewButton.Enabled;
            }
            set
            {
                viewButton.Enabled = value;
            }
        }

        // The method links the view with a controller and assigns handlers to controller's events
        // * зв'язування з контроллером одразу призначає опрацювання його подій
        public void SetSorter(InTaskSorter bs)
        {
            this.sorter = bs;
            this.sorter.SetArray(arrayToShow);
            this.sorter.SetProgress(Sorter_SortingExchange);
            this.sorter.SetContinuation(Sorter_SortingComplete);
        }
        public void SetMethod(System.Reflection.MethodInfo method)
        {
            this.sorter.SetMethod(method);
        }
        // перевіряти наявність сортера важливо з огляду на коректну заміну сортера тут і в колекції контроллера
        public bool HasSorter()
        {
            return this.sorter != null;
        }
        public void SetArray(int[] array)
        {
            this.arrayToShow = array;
            this.sorter.SetArray(array);
        }

        // The component signals about sorting completion
        // * сортування завершилося
        public event System.EventHandler SortingComplete;

        // The component signals about combobox event
        // * сигналізуємо про те, що хтось скористався комбобоксом
        public event EventHandler<ComboEventArgs> ComboIndexChanged;

        // Dispatcher of the component event
        // * диспетчери подій компоненти
        private void OnSortingComplete(EventArgs e) => SortingComplete?.Invoke(this, e);
        private void OnComboIndexChanged(ComboEventArgs e) => ComboIndexChanged?.Invoke(this, e);

        // Working up events happened with the component 
        // * опрацювання події складової частини компоненти
        private void ViewButton_Click(object sender, EventArgs e)
        {
            this.sorter.Stop();
            //this.viewButton.Visible = false;
        }
        // * компонента розпізнала подію комбобокса і сигналізує про це користувачеві
        private void CmbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnComboIndexChanged(new ComboEventArgs(cmbMethods.SelectedIndex));
        }
        private void ArraySortingView_SizeChanged(object sender, EventArgs e)
        {
            viewPanel.Height = Height - 25;
        }

        // "Graphical workhorses"
        // * "робочі конячки", що виконують усі графічні побудови

        // Panel draws itself with the array of integers anytime
        // * метод зображення панелі, заповненої масивом чисел
        // * потрібен для опрацювання події Paint головної форми
        // * не має стосунку до відображення ходу сортування
        private void PaintArray(Graphics g, int[] intArray)
        {
            for (int i = 0; i < intArray.Length; ++i)
                g.DrawLine(Pens.Red, new Point(0, 2 * i + 1),
                    new Point(intArray[i], 2 * i + 1));
        }
        // Vizualization of the array elements exchange
        // * відображення на панелі перестановок елементів у масиві
        // * під час сортування
         private void PaintExchange(int Index, int Value)
        {
            int y = Index * 2 + 1;
            Point P = new Point(Value, y);
            lock (this.Parent)
            {
                canvas.DrawLine(erasePen, new Point(171, y), P);
                canvas.DrawLine(Pens.Red, P, new Point(0, y));
            }
        }

        // * панель повинна зобразити себе разом з масивом
        private void ViewPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.arrayToShow != null) PaintArray(e.Graphics, this.arrayToShow);
        }

        // Handlers of the controller events
        // * методи опрацювання подій контроллера
        private void Sorter_SortingExchange((int index, int value) t)
        {
            PaintExchange(t.index, t.value);
        }
        // and signal the own event
        // *   + запуск власної події
        public void Sorter_SortingComplete()
        {
            this.viewButton.Visible = false;
            OnSortingComplete(null);
        }
    }

    public class ComboEventArgs : EventArgs
    {
        public int Index { get; private set; }
        public ComboEventArgs(int i)
        {
            Index = i;
        }
    }
}
