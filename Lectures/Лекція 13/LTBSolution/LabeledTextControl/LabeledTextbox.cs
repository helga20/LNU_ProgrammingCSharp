using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabeledTextControl
{
    [DefaultProperty("LabelText")]
    public partial class LabeledTextbox : UserControl
    {
        public LabeledTextbox()
        {
            InitializeComponent();
        }
        public enum PositionEnum
        {
            Right, Below
        }
        private PositionEnum m_Position = PositionEnum.Below;
        private int m_TextboxMargin = 0;

        [Category("Property Changed")]
        [Description("Event raised when the Position of the textbox is changed")]
        public event System.EventHandler PositionChanged;

        // UserControl вже має таку подію, але вона не відображається в інспекторі об'єктів
        // Єдиний спосіб виправити ситуацію - оголосити власну
        [Browsable(true)]
        [Category("Property Changed")]
        [Description("Event raised when the value of the Text property is changed on Control")]
        public new event System.EventHandler TextChanged;

        // Специфічні властивості компонента користувача
        [Category("Appearance")]
        [Description("Location of the textbox in relation to the label")]
        [DefaultValue(PositionEnum.Below)]
        public PositionEnum Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                if (value != m_Position)
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
            get
            {
                return m_TextboxMargin;
            }
            set
            {
                if (value != m_TextboxMargin)
                {
                    m_TextboxMargin = value;
                    AdjustControls();
                }
            }
        }
        private void CorrectMargin()
        {
            if (m_Position == PositionEnum.Right)
            {
                m_TextboxMargin = m_Label.Right;
            }
        }

        private void AdjustControls()
        {
            switch (m_Position)
            {
                case PositionEnum.Below:
                    m_Text.Left = m_Label.Left;
                    m_Text.Top = m_Label.Bottom + 3;
                    m_Text.Width = this.Width;
                    this.Height = m_Label.Height + m_Text.Height + 3;
                    break;
                case PositionEnum.Right:
                    m_Text.Left = m_TextboxMargin;
                    m_Text.Top = m_Label.Top;
                    m_Text.Width = this.Width - m_TextboxMargin;
                    this.Height = (m_Label.Height > m_Text.Height) ? m_Label.Height : m_Text.Height;
                    break;
            }
        }
        // Опрацювання важливих подій "базового" компонента
        private void LabeledTextbox_SizeChanged(object sender, EventArgs e)
        {
            AdjustControls();
        }

        private void LabeledTextbox_FontChanged(object sender, EventArgs e)
        {
            CorrectMargin();
            AdjustControls();
        }

        // Додаткові властивості, що дають доступ до властивостей складнових частин
        [Category("Appearance")]
        [Description("Caption of the control, the explanation text at the textbox")]
        public string LabelText
        {
            get
            {
                return m_Label.Text;
            }
            set
            {
                if (value != m_Label.Text)
                {
                    m_Label.Text = value;
                    CorrectMargin();
                    AdjustControls();
                }
            }
        }
        [Category("Appearance")]
        [Description("The text inputed to the textbox")]
        public string TextboxText
        {
            get
            {
                return m_Text.Text;
            }
            set
            {
                if (value != m_Text.Text) m_Text.Text = value;
            }
        }

        private void OnPositionChanged(EventArgs e)
        {
            if (PositionChanged != null) PositionChanged(this, e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (TextChanged != null) TextChanged(this, e);
        }
        // UserControl вже має події Key, залишається тільки активувати їх
        private void m_Text_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
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
    }
}
