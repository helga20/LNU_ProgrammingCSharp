using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SortingThreads
{
    // The class contains different methods for sorting in nondecreasing order an array of
    // integers: usual ones and methods adapted for interaction with a BackgroundWorker.
    // * Клас містить різноманітні методи впорядкування масиву цілих чисел (за зростанням):
    // * звичані та пристосовані до взаємодії з екземпляром BackgroundWorker
    public static class SortMethodProvider
    {
        private const int delay = 15;

        // Bubble sort algorithm (simple exchange method)
        // * впорядкування масиву цілих за зростанням методом обміну ("бульбашки")
        public static void BubbleSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = arrayToSort.Length - 1; i > 0; --i)
                for (int j = 0; j < i; ++j)
                {
                    // Cancel request checking
                    // * перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    // Looking for pairs of neighboring elements situated in wrong order
                    // * шукаємо "неправильні" пари сусідів
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        // Exchange vizualization in the main thread
                        // * відображення обміну в головному потоці
                        worker.ReportProgress(j * 1000 + (j + 1));
                        System.Threading.Thread.Sleep(delay);
                        // The exchange: to correct a "wrong pair" of elements
                        // * власне обмін - "виправляємо" пару сусідів
                        int t = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = t;
                    }
                }
        }

        // Improved bubble sort algorithm (compares first element with last one)
        // * впорядкування масиву цілих за зростанням методом зустрічного обміну
        public static void OppositeSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = 0; i < arrayToSort.Length - 1; ++i)
                for (int j = arrayToSort.Length - 1; j > i; --j)
                {
                    // Cancel request checking
                    // * перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    // Looking for pairs of elements situated in wrong order
                    // * шукаємо "неправильні" пари елементів
                    if (arrayToSort[i] > arrayToSort[j])
                    {
                        // Exchange vizualization in the main thread
                        // * відображення обміну в головному потоці
                        worker.ReportProgress(i * 1000 + j);
                        System.Threading.Thread.Sleep(delay);
                        // The exchange: to correct a "wrong pair" of elements
                        // * власне обмін - "виправляємо" пару елементів
                        int t = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[j];
                        arrayToSort[j] = t;
                    }
                }
        }

        // Quick sort algorithm (recursive). The front-end method calls working one,
        // which recursively does all work: separates the array to less and greater
        // part using median element as discriminant, than sorts both parts - less
        // and greater
        // * впорядкування за зростанням масиву цілих методом "швидкого сортування"
        // * front-end метод викликає рекурсивного колегу, який виконує всю роботу:
        // * елемент-дискримінант - медіана масиву; рекурсивне впорядкування лівої
        // * та правої частин масиву
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
            {   // Looking for a "wrong" value to the left and to the right from the discriminant
                // * шукаємо "неправильні" значення ліворуч та праворуч від дискримінанта
                while (array[Lo] < MidValue) ++Lo;
                while (array[Hi] > MidValue) --Hi;
                if (Lo <= Hi)
                {
                    // Cancel request checking
                    // * перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return false;
                    }
                    if (Lo < Hi)
                    {
                        // Exchange vizualization in the main thread
                        // * відображення обміну в головному потоці
                        worker.ReportProgress(Lo * 1000 + Hi);
                        System.Threading.Thread.Sleep(delay);
                        // The exchange: moving found values to proper parts of the array
                        // * власне обмін - переправляємо знайдені значення в "свою" частину
                        int t = array[Lo];
                        array[Lo] = array[Hi];
                        array[Hi] = t;
                    }
                    ++Lo; --Hi;
                }
            }
            while (Lo <= Hi);
            // Sorting the less and the greate part of the array (if it isn't empty)
            // * якщо є ще щось зліва/справа від дискримінанта - впорядковуємо і їх
            if (Hi > Low) result &= QBSort(Low, Hi, array, worker, e);
            if (result && Lo < High) result &= QBSort(Lo, High, array, worker, e);
            return result;
        }

        // Selection sort algorithm - sorting by finding maximal element
        // * впорядкування масиву цілих за зростанням методом вибору максимального
        public static void SelectionSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            for (int i = arrayToSort.Length - 1; i > 0; --i)
            {
                // Looking for maximal element index in the unsorted part of the array
                // * шукаємо номер найбільшого значення в масиві
                int indexOfMax = 0;
                for (int j = 1; j <= i; ++j)
                {
                    // Cancel request checking
                    // * перевірка на потребу зупинити потік
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
                    // Exchange vizualization in the main thread
                    // * відображення обміну в головному потоці
                    worker.ReportProgress(i * 1000 + indexOfMax);
                    System.Threading.Thread.Sleep(delay);
                    // The exchange: maximal with last element of the unsorted part
                    // * власне обмін - найбільшого з останнім у невпорядкованій частині
                    int t = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[indexOfMax];
                    arrayToSort[indexOfMax] = t;
                }
            }
        }

        // Batcher sort algorithm
        // * впорядкування масиву цілих за зростанням методом Бетчера
        public static void BatcherSortInBackground(int[] arrayToSort,
            BackgroundWorker worker, DoWorkEventArgs e)
        {
            // Calculating a power of 2 - first one greater then the array size
            // * відшукання степені 2 - першої більшої за розмір масиву
            int t = 1;
            while (t < arrayToSort.Length) t <<= 1;
            t >>= 1;
            // Looking over all p-subsequences
            // * перебір усіх р-підпослідовностей
            for (int p = t; p > 0; p >>= 1)
            {
                int q = t;
                int r = 0;
                int d = p;
                // Sorting & mergeing subsequences
                // * впорядкування і злиття підпослідовностей
                do
                {   // Cancel request checking
                    // * перевірка на потребу зупинити потік
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    for (int i = 0; i < arrayToSort.Length - d; ++i)
                    {
                        if (((i & p) == r) && (arrayToSort[i] > arrayToSort[i + d]))
                        {
                            // Exchange vizualization in the main thread
                            // * відображення обміну в головному потоці
                            worker.ReportProgress(i * 1000 + (i + d));
                            System.Threading.Thread.Sleep(delay);
                            // The exchange of two members of a p-subsequence
                            // * власне обмін двох членів р-підпослідовності
                            int swap = arrayToSort[i];
                            arrayToSort[i] = arrayToSort[i + d];
                            arrayToSort[i + d] = swap;
                        }
                    }
                    d = q - p;
                    q >>= 1;
                    r = p;
                }
                while (d != 0);
            }
        }

        // Synchronous versions of the same methods
        // * Ті самі методи. Синхронний варіант
        public static void BubbleSort(int[] arrayToSort)
        {
            Console.WriteLine("BubbleSort method works");
            for (int i = arrayToSort.Length - 1; i > 0; --i)
                for (int j = 0; j < i; ++j)
                {
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int t = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = t;
                    }
                }
        }
        public static void OppositeSort(int[] arrayToSort)
        {
            Console.WriteLine("OppositeSort method works");
            for (int i = 0; i < arrayToSort.Length - 1; ++i)
                for (int j = arrayToSort.Length - 1; j > i; --j)
                {
                    if (arrayToSort[i] > arrayToSort[j])
                    {
                        int t = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[j];
                        arrayToSort[j] = t;
                    }
                }
        }
        public static void QuickSort(int[] arrayToSort)
        {
            Console.WriteLine("QuickSort method works");
            QSort(0, arrayToSort.Length - 1, arrayToSort);
        }
        private static void QSort(int Low, int High, int[] arrayToSort)
        {
            int Lo = Low;
            int Hi = High;
            int MidValue = arrayToSort[(Lo + Hi) / 2];
            do
            {
                while (arrayToSort[Lo] < MidValue) ++Lo;
                while (arrayToSort[Hi] > MidValue) --Hi;
                if (Lo <= Hi)
                {
                    if (Lo < Hi)
                    {
                        int t = arrayToSort[Lo];
                        arrayToSort[Lo] = arrayToSort[Hi];
                        arrayToSort[Hi] = t;
                    }
                    ++Lo; --Hi;
                }
            }
            while (Lo <= Hi);
            if (Hi > Low) QSort(Low, Hi, arrayToSort);
            if (Lo < High) QSort(Lo, High, arrayToSort);
        }
        public static void SelectionSort(int[] arrayToSort)
        {
            Console.WriteLine("SelectionSort method works");
            for (int i = arrayToSort.Length - 1; i > 0; --i)
            {
                int indexOfMax = 0;
                for (int j = 1; j <= i; ++j)
                    if (arrayToSort[j] > arrayToSort[indexOfMax])
                        indexOfMax = j;
                if (indexOfMax != i)
                {
                    int t = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[indexOfMax];
                    arrayToSort[indexOfMax] = t;
                }
            }
        }
        public static void BatcherSort(int[] arrayToSort)
        {
            Console.WriteLine("BatcherSort method works");
            int t = 1;
            while (t < arrayToSort.Length) t <<= 1;
            t >>= 1;
            for (int p = t; p > 0; p >>= 1)
            {
                int q = t; int r = 0; int d = p;
                do
                {
                    for (int i = 0; i < arrayToSort.Length - d; ++i)
                    {
                        if ((i & p) == r)
                            if (arrayToSort[i] > arrayToSort[i + d])
                            {
                                int swap = arrayToSort[i];
                                arrayToSort[i] = arrayToSort[i + d];
                                arrayToSort[i + d] = swap;
                            }
                    }
                    d = q - p; q >>= 1; r = p;
                }
                while (d != 0);
            }
        }
    }
}
