using System;
using System.Windows.Forms;

namespace Lecture01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
            DialogResult result = MessageBox.Show("Hello, Worlr!\nWe are going!!!", 
                "First Of All", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (result)
            {
                case DialogResult.OK: Console.WriteLine("OK was pressed"); break;
                case DialogResult.Cancel: Console.WriteLine("Cancel was pressed"); break;
                default: Console.WriteLine("Nothing was pressed"); break;
            }
            Console.ReadLine();
        }
    }
}
