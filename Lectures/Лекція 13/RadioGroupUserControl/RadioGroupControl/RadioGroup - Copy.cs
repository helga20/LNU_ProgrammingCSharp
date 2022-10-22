using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.ComponentModel.Design;

namespace RadioGroupControl
{
    /// <summary>
    /// Provides a bounded group of radioButtons
    /// </summary>
    // The special designer provides handy behavior of the control at design time.
    [Description("Displays a bounded group of radioButtons")]
    [Designer(typeof(RadioGroupDesigner))]
    [DefaultEvent("IndexChanged")]
    public partial class RadioGroup: UserControl, ISupportInitialize
    {
        /// <summary>
        /// Specialized collection holds names of the radioButtons, can be sorted, signals changes
        /// </summary>
        public class NameCollection : StringCollection
        {
            public NameCollection() : base() { }

            // Event ItemsChanged signals that the collection of strings was changed,
            // provides additional information: if the collection needs to be sorted.
            public delegate void ItemsChangedEventHandler(object sender, ItemsChangedEventArgs e);
            public event ItemsChangedEventHandler ItemsChanged;
            private void OnItemsChanged(ItemsChangedEventArgs e)
            {
                if (ItemsChanged != null) ItemsChanged(this, e);
            }

            // We have to override the StringCollection's methods of items manipulating

            // Adding new item(s) changes the collection and make it unsorted.
            public new void Add(string item)
            {
                base.Add(item);
                OnItemsChanged(new ItemsChangedEventArgs(true));
            }
            public new void AddRange(string[] collection)
            {
                base.AddRange(collection);
                OnItemsChanged(new ItemsChangedEventArgs(true));
            }
            // Clearing removes all items from the collection
            public new void Clear()
            {
                base.Clear();
                OnItemsChanged(new ItemsChangedEventArgs(false));
            }
            // Insertion new item changes the collection and make it unsorted.
            public new void Insert(int index, string value)
            {
                base.Insert(index, value);
                OnItemsChanged(new ItemsChangedEventArgs(true));
            }
            // Removing item(s) changes the collection but keeps it sorted.
            public new void Remove(string Item)
            {
                int position = base.IndexOf(Item);
                if (position >= 0)
                {
                    base.RemoveAt(position);
                    OnItemsChanged(new ItemsChangedEventArgs(false));
                }
            }
            public new void RemoveAt(int position)
            {
                base.RemoveAt(position);
                OnItemsChanged(new ItemsChangedEventArgs(false));
            }
            // Direct access to an item can changes the collection and make it unsorted.
            public new string this[int index]
            {
                get
                {
                    return base[index];
                }
                set
                {
                    if (base[index] != value)
                    {
                        base[index] = value;
                        OnItemsChanged(new ItemsChangedEventArgs(true));
                    }
                }
            }
            // Sort the string collection by the simple insertion method - this method
            // will be effective enough while the collection will be almost sorted.
            public void Sort()
            {
                int curr = 1;
                while (curr < base.Count &&
                    String.Compare(base[curr - 1], base[curr], true,
                    System.Globalization.CultureInfo.CurrentCulture) < 0) ++curr;
                while (curr < base.Count)
                {
                    string toInsert = base[curr];
                    int pos = curr - 1;
                    while (pos >= 0)
                    {
                        if (String.Compare(base[pos], toInsert, true,
                            System.Globalization.CultureInfo.CurrentCulture) > 0)
                        {
                            base[pos + 1] = base[pos];
                            --pos;
                        }
                        else break;
                    }
                    base[pos + 1] = toInsert;
                    ++curr;
                }
                OnItemsChanged(new ItemsChangedEventArgs(false));
            }
        }

        /// <summary>
        /// Provides information if the NameCollection needs to be sorted
        /// </summary>
        public class ItemsChangedEventArgs : EventArgs
        {
            public readonly bool needSorting;
            public ItemsChangedEventArgs(bool needSorting)
            {
                this.needSorting = needSorting;
            }
        }

        /// <summary>
        /// Enumerates the possible directions to fill the component by radioButtons
        /// </summary>
        public enum Direction { TopDown, LeftToRight }

        private NameCollection names = new NameCollection();
        private List<RadioButton> buttons = new List<RadioButton>();
        private bool sorted = false;
        private int indexSelected = 0;
        private int columnCount = 1;
        private Direction direction = Direction.TopDown;

        public RadioGroup()
        {
            InitializeComponent();
            names.ItemsChanged += names_ItemsChanged;
        }

        // Handle the ItemsChanged event, reflect changes to the collection of radioButtons.
        private void names_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (sorted && e.needSorting) (sender as NameCollection).Sort();
            UpdateButtons();
        }

        // This property is mapped to the groupBox.Text property.
        // Category inherits from the base class.
        [Browsable(true)]
        [Description("Defines the title of the control, displayed in a gap of the border.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return theGrpBox.Text;
            }
            set
            {
                theGrpBox.Text = value;
            }
        }

        // The control contains as many buttons as Items property contains names for their.
        // Edit Items to manage the collection of buttons.
        [Category("Data")]
        [Description("The names of radiobuttons in the group.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(System.Drawing.Design.UITypeEditor))]
        public NameCollection Items
        {
            get
            {
                return this.names;
            }
            set
            {
                this.names = value;
                if (this.sorted) this.names.Sort();
                UpdateButtons();
            }
        }

        // Update names and number of the buttons every time the Items were changed.
        public void UpdateButtons()
        {
            // update names of the present buttons
            int minCount = (buttons.Count < names.Count) ? buttons.Count : names.Count;
            for (int i = 0; i < minCount; ++i) buttons[i].Text = names[i];
            if (buttons.Count > names.Count)
            {
                // remove excessive buttons
                for (int i = names.Count; i < buttons.Count; ++i)
                    buttons[i].Click -= button_Click;
                buttons.RemoveRange(names.Count, buttons.Count - names.Count);
                UpdateLayout();
                if (buttons.Count == 0) indexSelected = 0;
                else if (buttons.Count <= indexSelected)
                    IndexSelected = 0;
            }
            else if (buttons.Count < names.Count)
            {
                // add new buttons
                bool emptyGroup = buttons.Count == 0;
                for (int i = buttons.Count; i < names.Count; ++i )
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.AutoSize = true;
                    radioButton.TabStop = true;
                    radioButton.Click += button_Click;
                    radioButton.Text = names[i];
                    buttons.Add(radioButton);
                }
                UpdateLayout();
                // nonempty group has a button checked
                if (emptyGroup) buttons[indexSelected].Checked = true;
            }
        }

        // Update the tableLayoutPanel according to the number of buttons and to the Columns property.
        private void UpdateLayout()
        {
            // turn off the refresh of the screen until the panel be reconstructed
            theTableLtPnl.SuspendLayout();
            theTableLtPnl.Controls.Clear();

            int rowCount = buttons.Count / columnCount;
            if (buttons.Count % columnCount > 0) ++rowCount;
            if (theTableLtPnl.ColumnCount != columnCount || theTableLtPnl.RowCount != rowCount)
            {
                // The ColumnStyles collection was created at desighn time.
                // Therefore it is enough to set the ColumnCount property to manage columns in the table.
                theTableLtPnl.ColumnCount = columnCount;

                // The RowStyles collection is always created dynamically.
                theTableLtPnl.RowStyles.Clear();
                for (int i = 0; i < rowCount; ++i)
                {
                    theTableLtPnl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                }
            }
            // fill the table by the buttons acording to the FlowDirection property
            switch (this.direction)
            {
                case Direction.TopDown:
                {
                    int col = 0;
                    int row = 0;
                    for (int k = 0; k < buttons.Count; ++k )
                    {
                        theTableLtPnl.Controls.Add(buttons[k], col, row);
                        ++row;
                        if (row == rowCount)
                        {
                            row = 0;
                            ++col;
                        }
                    }
                    break;
                }
                case Direction.LeftToRight:
                {
                    int row = 0;
                    int col = 0;
                    for (int k = 0; k < buttons.Count; ++k)
                    {
                        theTableLtPnl.Controls.Add(buttons[k], col, row);
                        ++col;
                        if (col == columnCount)
                        {
                            col = 0;
                            ++row;
                        }
                    }
                    break;
                }
            }
            // the construction is complete - refresh the display
            theTableLtPnl.ResumeLayout();
        }

        // Every click on a radioButton can change selection in the group and initiate the IndexChanged event.
        // Also the radioButton.Click event signals Click to the parent control.
        private void button_Click(object sender, EventArgs e)
        {
            // do not assign directly to the IndexSelected property to avoid a circular calling
            int indexClicked = buttons.IndexOf(sender as RadioButton);
            if (indexClicked != indexSelected)
            {
                indexSelected = indexClicked;
                OnIndexChanged(new EventArgs());
            }
            OnClick(e);
        }

        // Handle the DoubleClick event of the tableLayoutPanel, transfer the event to the parent control.
        private void theTableLtPnl_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        [Category("Behavior")]
        [Description("Controls whether the list of names of the buttons is sorted.")]
        [DefaultValue(false)]
        public bool Sorted
        {
            get
            {
                return this.sorted;
            }
            set
            {
                if (!sorted && value)
                {
                    this.names.Sort();
                    this.sorted = true;
                }
                else this.sorted = value;
            }
        }

        [Category("Behavior")]
        [Description("Set or get zero based index of the selected radioButton.")]
        [DefaultValue(0)]
        public int IndexSelected
        {
            get
            {
                return this.indexSelected;
            }
            // The setter acts in a different way if the control is initializing: validation of the value
            // is postponed to the ISupportInitialize.EndInit() call.
            // The buttons will be updated after the Items property set.
            set
            {
                if (this.indexSelected != value)
                {
                    if (isInitializing)
                        this.indexSelected = value;
                    else
                    {
                        CompleteSetIndexSelected(value);
                        OnIndexChanged(new EventArgs());
                    }
                }
            }
        }
        // Internal method, written for the SupportInitialize Interface implementation
        private void CompleteSetIndexSelected(int value)
        {
            if (value < 0 || value >= this.names.Count)
            {
                throw new ArgumentOutOfRangeException("IndexSelected",
                    String.Format("Invalid Argument \"{0}\" is out of the range [0; {1}] of the buttons indexes",
                        value, this.names.Count - 1));
            }
            this.indexSelected = value;
            this.buttons[indexSelected].Checked = true;
        }

        [Category("Property Changed")]
        [Description("Occurs whenewer the checked button changes (the 'IndexSelected' property changes).")]
        public event EventHandler IndexChanged;
        private void OnIndexChanged(EventArgs e)
        {
            if (IndexChanged != null) IndexChanged(this, e);
        }

        [Category("Appearance")]
        [Description("Defines quantity of columns the group will be separated to.")]
        [DefaultValue(1)]
        public int ColumnCount
        {
            get
            {
                return columnCount;
            }
            // The setter has to update the tableLayoutPanel only at design time or at run time.
            // In the initializing mode the tableLayoutPanel will be updated after the Items property set.
            set
            {
                if (value < 1) value = 1;
                else if (value > 8) value = 8;
                if (columnCount != value)
                {
                    if (isInitializing)
                        columnCount = value;
                    else
                    {
                        columnCount = value;
                        UpdateLayout();
                    }
                }
            }
        }
        [Category("Layout")]
        [Description("Specifies the direction in which radioButtons are laid out.")]
        [DefaultValue(typeof(Direction), "TopDown")]
        public Direction FlowDirection
        {
            get
            {
                return direction;
            }
            // The setter has to update the tableLayoutPanel only at design time or at run time.
            // In the initializing mode the tableLayoutPanel will be updated after the Items property set.
            set
            {
                if (direction != value)
                {
                    if (isInitializing)
                        direction = value;
                    else
                    {
                        direction = value;
                        UpdateLayout();
                    }
                }
            }
        }

        // Hide inherited event Click to change its BrowsableAttribute
        [Browsable(false)]
        public new event EventHandler Click;
        private void OnClick(EventArgs e)
        {
            if (Click != null) Click(this, e);
        }

        #region SupportInitialize Interface implementation

        private bool isInitializing = false;
        void ISupportInitialize.BeginInit()
        {
            isInitializing = true;
        }
        void ISupportInitialize.EndInit()
        {
            isInitializing = false;
            CompleteSetIndexSelected(indexSelected);
        }
        #endregion
    }
}
