using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace UnmanagedMemory
{
    unsafe class MyDataClass
    {
        IntPtr _memory = IntPtr.Zero;

        public int NumObjects { get; private set; }
        public int MemorySize { get { return sizeof(Int32) * NumObjects; } }
        
        public MyDataClass(int numObjects)
        {
            this.NumObjects = numObjects;
            
            _memory = Marshal.AllocHGlobal(MemorySize);
            //we should tell the garbage collector that we are using more 
            // memory so it can schedule collections better 
            //(note--it still doesn't change the amount that GC.GetTotalMemory returns)
            GC.AddMemoryPressure(MemorySize);

            Int32* pI = (Int32*)_memory;
            for (int i = 0; i < NumObjects; ++i)
            {
                pI[i] = i;
            }
        }

        //unmanaged resources need a finalizer to make sure they're cleaned up!
        ~MyDataClass()
        {
            if (_memory != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_memory);
                //tell garbage collector memory is gone
                GC.RemoveMemoryPressure(MemorySize);
            }
        }
    }
}
