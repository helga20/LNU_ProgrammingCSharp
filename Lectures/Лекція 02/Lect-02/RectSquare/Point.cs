using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectSquare
{
    struct Point
    {
        public double x;
        public double y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("({0};{1})", x, y);
        }
        public void addToX(double a)
        {
            x += a;
        }
        public void addToY(double b)
        {
            y += b;
        }
    }
}
