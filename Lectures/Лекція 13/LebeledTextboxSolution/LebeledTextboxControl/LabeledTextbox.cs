using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LebeledTextboxControl
{
    public partial class LabeledTextbox: UserControl
    {
        public LabeledTextbox()
        {
            InitializeComponent();
        }
        // можливі позиції
        public enum PositionEnum
        {
            Right, Below
        }
        private PositionEnum m_Position = PositionEnum.Below;
        private int m_TexboxMargin = 0;
        // властивості компонента користувача
        [Category("Appearance")]
        [Description("Location of the textbox in relation to the label")]
        [DefaultValue(PositionEnum.Below)]
        public PositionEnum Position
        {
            get { return m_Position; }
            set
            {
                if(m_Position!= value)
                {
                    m_Position = value;
                    CorrectMargin();
                    AdjustControls();
                    OnPositionChanged(new EventArgs());
                }
            }
        }
        [Category("Appearance")]
        [Description("Distance between the label and the textbox if Position property is equal to Right")]
        [DefaultValue(0)]
        public int TextboxMargin
        {
            get { return m_TexboxMargin; }
            set
            {
                if(m_TexboxMargin!= value)
                {
                    m_TexboxMargin = value;
                    AdjustControls();
                }
            }
        }
        private void CorrectMargin()
        {
            if(m_Position==PositionEnum.Right)
            {
                m_TexboxMargin = m_Label.Right;
            }
        }
        // позиціонування елементів компонента
        private void AdjustControls()
        {
            switch(m_Position)
            {
                case PositionEnum.Right:
                    // Textbox на одному рівні з label
                    m_Text.Left = m_TexboxMargin;
                    m_Text.Top = m_Label.Top;
                    m_Text.Width = this.Width - m_TexboxMargin;
                    // Textbox там, де вказав користувач
                    this.Height = (m_Label.Height > m_Text.Height) ? m_Label.Height : m_Text.Height;
                    break;
                case PositionEnum.Below:
                    // Textbox під label (не попала на початку по кнопках і не помітила цього, тому TexboxMargin)
                    m_Text.Left = m_Label.Left;
                    m_Text.Top = m_Label.Bottom + 3;
                    // зміна ширини Textbox (= ширині компонента)
                    m_Text.Width = this.Width;
                    this.Height = m_Label.Height + m_Text.Height + 3;
                    break;
            }
        }
        // опрацювання важливих подій "базового" компонента
        private void LabeledTextbox_SizeChanged(object sender, EventArgs e)
        {
            AdjustControls();
        }
        // додаткові властивості
        [Category("Appearance")]
        [Description("Caption of the control, the explanation text at the textbox")]
        public string LabelText
        {
            get { return m_Label.Text; }
            set
            {
                if (m_Label.Text != value)
                {
                    m_Label.Text = value;
                    CorrectMargin();
                    AdjustControls();
                }
            }
        }
        // текст введено в Тextbox
        [Category("Appearance")]
        [Description("The text inputed to the textbox")]
        public string TextboxText
        {
            get { return m_Text.Text; }
            set
            {
                if (m_Text.Text != value)
                {
                    m_Text.Text = value;
                }
            }
        }
        // переадресування події від внутрішньої частини до самого компонента
        private void m_Text_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e); //диспетчер, який виклече подію KeyDown у створеного User Control y LabelTextbox
        }
        private void m_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }
        private void m_Text_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }
        private void m_Text_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }
        // подія, що виникає, коли значення Text змінено на Control
        [Browsable(true)]
        [Category("Property Changed")]
        [Description("Event raised when the value of the Text property is changed on Control")]
        public new event System.EventHandler TextChanged;
        protected override void OnTextChanged(EventArgs e)
        {
            if(TextChanged != null)
            {
                TextChanged(this, e);
            }
        }
        // подія, що виникає при зміні позиції Textbox
        [Category("Property Changed")]
        [Description("Event raised when the Position of the textbox is changed")]
        public event System.EventHandler PositionChanged;
        private void OnPositionChanged(EventArgs e)
        {
            if (PositionChanged != null)
            {
                PositionChanged(this, e);
            }
        }

    }
}
