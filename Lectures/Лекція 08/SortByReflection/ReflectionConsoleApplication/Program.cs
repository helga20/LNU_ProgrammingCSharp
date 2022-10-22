using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using SortingThreads;

namespace ReflectionConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(SortMethodProvider);
            Console.WriteLine("Analysis of type " + t.Name);
            AnalyzeType(t);
            Console.ReadLine();

            string methodName = String.Empty;
            Console.Write("Input a name of the sort method: ");
            methodName = Console.ReadLine();
            MethodInfo M = t.GetMethod(methodName);
            if (M == null)
            {
                Console.WriteLine("No method was found");
                Console.ReadLine();
                return;
            }
            int[] a = { 6, 2, 1, 9, 3, 0, 7, 5, 4, 8};

            M.Invoke(null, new object[] { a });
            foreach (int x in a)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
        static void AnalyzeType(Type t)
        {
            Console.WriteLine("Type Name: " + t.Name);
            Console.WriteLine("Full Name: " + t.FullName);
            Console.WriteLine("Namespace: " + t.Namespace);
            Type tBase = t.BaseType;
            if (tBase != null)
            {
                Console.WriteLine("Base Type:" + tBase.Name);
            }
            Console.WriteLine("\nPUBLIC MEMBERS:");
            MemberInfo[] Members = t.GetMembers();
            foreach (MemberInfo NextMember in Members)
            {
                Console.WriteLine(NextMember.DeclaringType + " " +
                NextMember.MemberType + " " + NextMember.Name);
            }
            Console.WriteLine("\nDETAILS OF METHODS:");
            MethodInfo[] Methods = t.GetMethods();
            foreach (MethodInfo m in Methods)
            {
                string retVal = m.ReturnType.FullName;
                string paramInfo = "( ";
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    paramInfo += string.Format("\n     {0} {1} ", pi.ParameterType, pi.Name);
                }
                paramInfo += " )";
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            Console.WriteLine();
        }
    }
}
