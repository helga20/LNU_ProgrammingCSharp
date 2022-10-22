using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace ButtonWithSoundControl
{
    public partial class ButtonWithSound: UserControl
    {
        public ButtonWithSound()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {    
            try
            {
                using (var soundPlayer = new SoundPlayer(@"D:\Навчання\1 - 4 семестри\Програмування (C#)\Лекції\Лекція 13\ButtonWithSoundSolution\zvuk.wav"))
                {
                    soundPlayer.Play(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка відтворення звуку кнопки");
            }
        }
    }
}
