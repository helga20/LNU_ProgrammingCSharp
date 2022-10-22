using System;
using System.Drawing;

namespace CrossLightsModel
{
    class TrafficLights
    {
        private Lamp[] lamps;
        private uint activeLamp;
        private Graphics graphics;
        private bool blink;

        public TrafficLights(Graphics gr)
        {
            graphics = gr;
            blink = false;
            activeLamp = 0;
            lamps = new Lamp[4]
            {
                new Lamp(30, 30, Color.Red, 5000),
                new Lamp(30, 160, Color.Yellow, 1000),
                new Lamp(30, 290, Color.Green, 5000),
                null
            };
            lamps[3] = lamps[1];
            lamps[activeLamp].SwitchOn();
        }

        public void BlinkOn()
        {
            blink = true;
            for (int i = 0; i < 3; ++i) lamps[i].SwitchOff();
            activeLamp = 1;
            lamps[activeLamp].SwitchOn();
        }
        public void BlinkOff()
        {
            blink = false;
        }
        public void ChangeLamp()
        {
            if (blink)
            {
                if (lamps[activeLamp].IsSwitchedOn)
                    lamps[activeLamp].SwitchOff().Draw(graphics);
                else lamps[activeLamp].SwitchOn().Draw(graphics);
            }
            else
            {
                lamps[activeLamp].SwitchOff().Draw(graphics);
                activeLamp = ++activeLamp % 4;
                lamps[activeLamp].SwitchOn().Draw(graphics);
            }
        }

        public void Draw()
        {
            for (uint i = 0; i < 3; ++i) lamps[i].Draw(graphics);
        }

        public int GetInterval()
        {
            return (int)lamps[activeLamp].Period;
        }

        public void SetInterval(int k, uint p)
        {
            lamps[k].Period = p;
        }
    }
}
