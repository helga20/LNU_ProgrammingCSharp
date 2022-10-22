using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSortLibrary
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MethodNameAttribute : System.Attribute
    {
        public string OuterName { get; set; }
        public MethodNameAttribute(string name)
        {
            OuterName = name;
        }
    }

    public static class SortMethodProvider
    {
        private const int delay = 15;

        [MethodNameAttribute("Метод бульбашки")]
        // впорядкування масиву цілих за зростанням методом обміну ("бульбашки")
        public static void BubbleSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = arrayToSort.Length - 1; i > 0; --i)
                for (int j = 0; j < i; ++j)
                {
                    // перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    // шукаємо "неправильні" пари сусідів
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        // відображення обміну в головному потоці
                        //worker.ReportProgress(j * 1000 + (j + 1));
                        // власне обмін - "виправляємо" пару сусідів
                        int t = arrayToSort[j];
                        worker.ReportProgress(257 * 1000 + arrayToSort[j]);
                        arrayToSort[j] = arrayToSort[j + 1];
                        worker.ReportProgress(j * 1000 + arrayToSort[j + 1]);
                        arrayToSort[j + 1] = t;
                        worker.ReportProgress((j + 1) * 1000 + t);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
        }

        [MethodNameAttribute("Зустрічний обмін")]
        // впорядкування масиву цілих за зростанням методом зустрічного обміну
        public static void SelectionSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = 0; i < arrayToSort.Length - 1; ++i)
                for (int j = arrayToSort.Length - 1; j > i; --j)
                {
                    // перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    // шукаємо "неправильні" пари елементів
                    if (arrayToSort[i] > arrayToSort[j])
                    {
                        // відображення обміну в головному потоці
                        //worker.ReportProgress(i * 1000 + j);
                        // власне обмін - "виправляємо" пару сусідів
                        int t = arrayToSort[i];
                        worker.ReportProgress(257 * 1000 + arrayToSort[i]);
                        arrayToSort[i] = arrayToSort[j];
                        worker.ReportProgress(i * 1000 + arrayToSort[j]);
                        arrayToSort[j] = t;
                        worker.ReportProgress(j * 1000 + t);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
        }

        [MethodNameAttribute("Швидке сортування")]
        // впорядкування за зростанням масиву цілих методом "швидкого сортування"
        // front-end метод викликає рекурсивного колегу, який виконує всю роботу:
        // елемент-дискримінант - медіана масиву; рекурсивне впорядкування лівої
        // та правої частин масиву
        public static void QuickSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            QBSort(0, arrayToSort.Length - 1, arrayToSort, worker, e);
        }
        private static bool QBSort(int Low, int High, int[] array,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            bool result = true;
            int Lo = Low;
            int Hi = High;
            int MidValue = array[(Lo + Hi) / 2];
            do
            {   // шукаємо "неправильні" значення ліворуч та праворуч від дискримінанта
                while (array[Lo] < MidValue) ++Lo;
                while (array[Hi] > MidValue) --Hi;
                if (Lo <= Hi)
                {
                    // перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return false;
                    }
                    if (Lo < Hi)
                    {
                        // відображення обміну в головному потоці
                        //worker.ReportProgress(Lo * 1000 + Hi);
                        // власне обмін - переправляємо знайдені значення в "свою" частину
                        int t = array[Lo];
                        worker.ReportProgress(257 * 1000 + array[Lo]);
                        array[Lo] = array[Hi];
                        worker.ReportProgress(Lo * 1000 + array[Hi]);
                        array[Hi] = t;
                        worker.ReportProgress(Hi * 1000 + t);
                        System.Threading.Thread.Sleep(delay);
                    }
                    ++Lo; --Hi;
                }
            }
            while (Lo <= Hi);
            // якщо є ще щось зліва/справа від дискримінанта - впорядковуємо і їх
            if (Hi > Low) result &= QBSort(Low, Hi, array, worker, e);
            if (result && Lo < High) result &= QBSort(Lo, High, array, worker, e);
            return result;
        }

        [MethodNameAttribute("Вибір максимального")]
        // впорядкування масиву цілих за зростанням методом вибору максимального
        public static void FindSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = arrayToSort.Length - 1; i > 0; --i)
            {
                // шукаємо номер найбільшого значення в масиві
                int indexOfMax = 0;
                for (int j = 1; j <= i; ++j)
                {
                    // перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (arrayToSort[j] > arrayToSort[indexOfMax])
                        indexOfMax = j;
                }
                if (indexOfMax != i)
                {
                    // відображення обміну в головному потоці
                    //worker.ReportProgress(i * 1000 + indexOfMax);
                    // власне обмін - найбільшого з останнім у невпорядкованій частині
                    int t = arrayToSort[i];
                    worker.ReportProgress(257 * 1000 + arrayToSort[i]);
                    arrayToSort[i] = arrayToSort[indexOfMax];
                    worker.ReportProgress(i * 1000 + arrayToSort[indexOfMax]);
                    arrayToSort[indexOfMax] = t;
                    worker.ReportProgress(indexOfMax * 1000 + t);
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }
    }
}
