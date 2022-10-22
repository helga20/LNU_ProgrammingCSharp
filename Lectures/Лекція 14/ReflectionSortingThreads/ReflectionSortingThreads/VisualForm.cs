using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReflectionSortingThreads
{
    public partial class VisualForm : Form
    {
        // Variables to control the interface state:
        // * змінні для керування станом інтерфейсу:
        // - counter of running sort methods
        private int threadsRunning;     // * кількість "потоків сортування"
        // - arrays remain in two states: randomized or sorted
        private bool arraysAreRandom;   // ознака того, чи масиви вже відсортовано

        // the form holds a collection of ArrayView components. An user can add/remove views dynamically
        private readonly int[] xLocation = { 12, 195, 378, 561, 744 };
        private readonly List<ArrayView.ArrayView> Views;

        // the model responds for arrays generation and storage
        // the controller provides BackGroundSorters
        private readonly SortModel model;
        private readonly SortController controller;

        public VisualForm()
        {
            InitializeComponent();
            
            Views = new List<ArrayView.ArrayView>(5);
            model = new SortModel((int)this.sizeUpDown.Value);
            controller = new SortController();
            // add an empty view
            threadsRunning = 0;
            arraysAreRandom = true;
            // set default number of a generation method
            cmBoxGen.SelectedIndex = 0;
        }

        // Changing of index of the combobox in an arrayView causes changing of the sorting algorithm
        private void ArrayView_ComboIndexChanged(object sender, ArrayView.ComboEventArgs e)
        {
            (sender as ArrayView.ArrayView).SetMethod(controller.GetMethod(e.Index));
            btnSort.Enabled = threadsRunning == 0;
        }

        // Dynamic creation of a new arrayView component
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int i = Views.Count;
            // an array to sort and view
            ArrayView.ArrayView a = new ArrayView.ArrayView(new Point(xLocation[i], 41), model.GetArray());
            // set names to the arrayView's combobox
            a.AddRange(controller.MethodNames);
            // set event handlers
            a.ComboIndexChanged += ArrayView_ComboIndexChanged;
            a.SortingComplete += DecreaseThreadsRunning;
            // set a new backGroundSorter
            
            a.SetSorter(controller.GetSorter());
            // visualize new component
            a.Parent = this;
            Views.Add(a);
            btnRemove.Enabled = i > 0;
            btnAdd.Enabled = i < 4;
        }

        // Dynamic removing of the arrayView component and related sorter
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int i = Views.Count;
            Views[i - 1].Visible = false;
            controller.RemoveSorter();
            Views.RemoveAt(i - 1);
            btnRemove.Enabled = i > 2;
            btnAdd.Enabled = true;
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            if (arraysAreRandom)
            {
                // Changing interface state
                // * налаштування інтерфейсу
                for (int i = 0; i < Views.Count; ++i)
                {
                    if (Views[i].HasSorter())
                    {
                        Views[i].ButtonIsVisible = true;
                        ++threadsRunning;
                    }
                }
                btnSort.Enabled = false;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                // Starting sorting threads
                // * запуск на виконання потоків сортування
                controller.StartAll();
            }
            else
            {
                // Generating new integer values
                // * генерування нових значень
                model.ArraySize = (int)sizeUpDown.Value;
                switch (cmBoxGen.SelectedIndex)
                {
                    case 0: model.RandomizeArray(); break;
                    case 1: model.NearlySortedArray(); break;
                    case 2: model.FewValuedArray(); break;
                    case 3: model.ReversedArray(); break;
                }
                
                foreach (ArrayView.ArrayView av in Views) av.SetArray(model.GetArray());
                arraysAreRandom = true;

                // Redrawing the window with new arrays
                // * перемальовування вікна новими масивами
                Refresh();
                //btnSort.Text = "Сортувати";
                btnSort.Text = "Sort";
            }
        }

        private void VisualForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = threadsRunning > 0;
        }

        private void DecreaseThreadsRunning(object sender, EventArgs e)
        {
            lock (this)     // блокування обов'язкове,
            {               // бо різні потоки намагаються зробити це
                --threadsRunning;
            }
            if (threadsRunning == 0)
            {
                //btnSort.Text = "Генерувати";
                btnSort.Text = "Generate";
                btnSort.Enabled = true;
                btnAdd.Enabled = Views.Count < 5;
                btnRemove.Enabled = Views.Count > 1;
                arraysAreRandom = false;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK &&
                controller.LoadAssembly(openFileDialog.FileName))
            {
                BtnAdd_Click(this, null);
                btnLoad.Enabled = false;
            }
        }

    }
}
