using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseGarbageCollector
{
    class Simple // usual class
    {
        private static int counter = 0;
        public string Name
        {
            get;
            set;
        }
        public Simple(string name)
        {
            Name = name;
        }
        public Simple()
        {
            Name = string.Format("#{0}", ++counter);
        }
        public override string ToString()
        {
            return string.Format("Simple({0})", Name);
        }
    }

    class Final: Simple // finalizeable class
    {
        public Final(string name) : base(name) { }
        public Final() : base() { }
        public override string ToString()
        {
            return string.Format("Final[{0}]", Name);
        }
        ~Final()
        {
            Console.WriteLine("{0} said 'Bye!'", this);
        }
    }
    class Disp : Simple, IDisposable
    {
        public Disp(string name) : base(name) { }
        public Disp() : base() { }
        public override string ToString()
        {
            return string.Format("Disp<{0}>", Name);
        }
        public void Dispose()
        {
            Console.WriteLine("{0} is disposing", this);
        }
    }
    class Both : Simple, IDisposable
    {
        public Both(string name) : base(name) { }
        public Both() : base() { }
        private bool disposed = false;
        private void CleanUp(bool disposing)
        {
            // Check if disposing is completed
            if (!this.disposed)
            {
                if (disposing)
                {
                    Console.WriteLine(" ... {0} is disposing managed resources", this);
                }
                Console.WriteLine(" ... {0} is disposing UNMANAGED resources", this);
            }
            disposed = true;
        }
        public void Dispose()
        {
            Console.WriteLine("{0} is disposing", this);
            CleanUp(true);
            GC.SuppressFinalize(this);
        }
        ~Both()
        {
            Console.WriteLine("{0} said 'Bye!'", this);
            CleanUp(false);
        }
        public override string ToString()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("Both");
            }
            return string.Format("Both[<{0}>]", Name);
        }
    }
}
