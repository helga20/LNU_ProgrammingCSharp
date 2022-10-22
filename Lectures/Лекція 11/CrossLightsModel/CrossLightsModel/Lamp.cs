using System;
using System.Drawing;

namespace CrossLightsModel
{
    class Lamp
    {
        private const int sizeOfLamp = 120;
        private Rectangle bounds;  // розташування + розмір
        private SolidBrush brush;  // колір заповнення
        private static SolidBrush GrayBrush = new SolidBrush(Color.LightGray);
        //private uint period;       // тривалість світіння
        private bool switchedOn;

        public Lamp(int left, int top, Color c, uint p)
        {
            bounds = new Rectangle(left, top, sizeOfLamp, sizeOfLamp);
            brush = new SolidBrush(c);
            Period = p;
            switchedOn = false;
        }
        
        public uint Period { get; set; }

        public Lamp SwitchOn()
        {
            switchedOn = true;
            return this;
        }
        public Lamp SwitchOff()
        {
            switchedOn = false;
            return this;
        }
        public bool IsSwitchedOn
        {
            get
            {
                return switchedOn;
            }
        }
        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(IsSwitchedOn ? brush : GrayBrush, bounds);
            graphics.DrawEllipse(Pens.Black, bounds);
        }
    }
}
