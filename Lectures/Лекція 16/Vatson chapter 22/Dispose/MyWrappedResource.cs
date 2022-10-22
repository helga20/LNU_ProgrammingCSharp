using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;

namespace Dispose
{
    public class MyWrappedResource : IDisposable
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
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

        //our managed resource
        IDbConnection _conn = null;

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

        //Finalizers look like C++ destructors, but they are NOT deterministic
        ~MyWrappedResource()
        {
            //note: in real apps, don't put anything in finalizers that doesn't
            //need to be there
            Console.WriteLine("In Finalizer");
            Dispose(false);
        }

        public void Close()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed = false;
        protected void Dispose(bool disposing)
        {
            //in a class hierarchy, don't forget to call the base class!
            //base.Dispose(disposing);

            Console.WriteLine("Dispose({0})", disposing);
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    //cleanup managed resources
                    if (_conn!=null)
                    {
                        _conn.Dispose();
                    }
                    GC.SuppressFinalize(this);
                }

                //cleanup unmanaged resources, if any
                if (_handle!=IntPtr.Zero)
                {
                    CloseHandle(_handle);
                }
            }
        }
    }
}
