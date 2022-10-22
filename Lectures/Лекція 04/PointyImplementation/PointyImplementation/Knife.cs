using System;

namespace PointyImplementation
{
    class Knife : IPointy
    {
        public override string ToString()
        {
            return "I am very cutting knife";
        }
        public byte Points
        {
            get { return 2; }
        }
    }
}
