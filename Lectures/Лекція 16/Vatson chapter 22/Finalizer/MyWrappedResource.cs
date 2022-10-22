using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Finalizer
{
    public class MyWrappedResource 
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, 
            CallingConvention = CallingConvention.StdCall, 
            SetLastError = true)]
        public static extern IntPtr CreateFile(
              string lpFileName,
              uint dwDesiredAccess,
              uint dwShareMode,
              IntPtr SecurityAttributes,
              uint dwCreationDisposition,
              uint dwFlagsAndAttributes,
              IntPtr hTemplateFile
              );
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        //IntPtr is used to represent OS handles
        IntPtr _handle = IntPtr.Zero;
        
        public MyWrappedResource(string filename)
        {
            _handle = CreateFile(filename,
                0x80000000, //access read-only
                1,          //share-read
                IntPtr.Zero,
                3,          //open existing
                0,
                IntPtr.Zero);
        }

        //Finalizers look like C++ destructors, 
        //but they are NOT deterministic
        ~MyWrappedResource()
        {
            //note: in real apps, don't put anything 
            //in finalizers that doesn't need to be there
            Console.WriteLine("In Finalizer");
            if (_handle != IntPtr.Zero)
            {
                CloseHandle(_handle);
            }
        }

        public void Close()
        {
            if (_handle != IntPtr.Zero)
            {
                //we're already closed, so this object 
                //doesn't need to be finalized anymore
                GC.SuppressFinalize(this);
                CloseHandle(_handle);
            }
        }
    }
}
