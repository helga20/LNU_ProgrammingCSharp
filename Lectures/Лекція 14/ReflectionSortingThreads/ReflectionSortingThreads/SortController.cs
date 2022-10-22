using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TaskWorker;

namespace ReflectionSortingThreads
{
    // Controller detects proper sorting methods marked by the custom attributes,
    // collects interface names of these methods. Controller also creates a backgroundSorter 
    // with related sorting method and manages the collection of the sorters.
    // * Контроллер відповідальний за рефлексію: колекціонує статичні методи класу SortMethodProvider,
    // * позначені відповідними атрибутами; визначає інтерфейсні імена цих методів
    // * Контроллер створює сортери (за номером методу сортування) і менеджить колекцію сортерів
    public class SortController
    {
        private MethodInfo[] methods;
        private string[] methodNames;
        //private List<BackgroundSorter> sorters;
        private List<InTaskSorter> sorters;
        //private string assemblyName = "SortingLibrary";

        public SortController()
        {
            methods = null;
            methodNames = null;
            sorters = new List<InTaskSorter>(5);
        }
        public bool LoadAssembly(string assemblyName)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(assemblyName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Sorting assembly error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // We suppose that the assembly name coincides with the name of its namespace
            string nameOfNamespace = System.IO.Path.GetFileNameWithoutExtension(assemblyName);
            System.Type sortMethodProviderType = assembly.GetType(nameOfNamespace + ".SortMethodProvider");
            System.Type methodNameAttrType = assembly.GetType(nameOfNamespace + ".TaskNameAttribute");
            if (sortMethodProviderType == null || methodNameAttrType == null)
            {
                MessageBox.Show(
                    "SortMethodProvider or TaskNameAttribute not found in " + assemblyName + " assembly",
                    "Sorting assembly error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            methods = (from m in sortMethodProviderType.GetMethods()
                       where (m.IsStatic && m.IsDefined(methodNameAttrType, false))
                       select m).ToArray<MethodInfo>();

            methodNames = new string[methods.Length];
            //PropertyInfo propInfo = methodNameAttrType.GetProperty("OuterName");
            PropertyInfo propInfo = methodNameAttrType.GetProperty("LocalName");
            for (int i = 0; i < methods.Length; ++i)
                methodNames[i] = propInfo.GetValue(methods[i].GetCustomAttribute(methodNameAttrType)).ToString();
            sorters = new List<InTaskSorter>(5);
            return true;
        }

        public MethodInfo GetMethod(int i)
        {
            return methods[i];
        }

        public string[] MethodNames
        {
            get { return methodNames; }
        }

        public InTaskSorter GetSorter()
        {
            InTaskSorter sorter = new InTaskSorter();
            sorters.Add(sorter);
            return sorter;
        }

        public void RemoveSorter()
        {
            sorters.RemoveAt(sorters.Count - 1);
        }

        public void StartAll()
        {
            foreach (InTaskSorter sorter in sorters) sorter.Start();
        }
    }
}
