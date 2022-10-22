using System;

namespace ReflectionSortingThreads
{
    // The model stores the standard array of integes, fill it by different values
    // and provides copy of it for a sorting algorithm
    // * Модель зберігає еталонний масив, заповнює різними значеннями
    // * постачає копію еталону для використання в алгоритмах сортування
    public class SortModel
    {
        private int[] theArray;
        private readonly Random generator;

        // Changeing of the array size leads to generating a new array
        // зміна розміру спричиняє створення нового масиву і наповнення його значеннями
        public int ArraySize
        {
            get
            {
                return theArray.Length;
            }
            set
            {
                if (theArray.Length != value)
                {
                    theArray = new int[value];
                    RandomizeArray();
                }
            }
        }

        public SortModel(int size)
        {
            generator = new Random();
            theArray = new int[size];
            RandomizeArray();
        }

        public int[] GetArray()
        {
            return (int[])theArray.Clone();
        }

        // Different ways to fullfil the array
        public void RandomizeArray()
        {
            for (int i = 0; i < ArraySize; ++i) theArray[i] = generator.Next(170) + 1;
        }

        public void ReversedArray()
        {
            double h = 170.0 / ArraySize;
            for (int i = 0; i < ArraySize; ++i) theArray[i] = 1 + (int)((ArraySize - i) * h);
        }

        public void NearlySortedArray()
        {
            double h = 170.0 / ArraySize;
            for (int i = 0; i < ArraySize; ++i) theArray[i] = 1 + (int)(i * h);
            for (int i = 0; i < (ArraySize / 20); ++i)
            {
                int a = generator.Next(ArraySize);
                int b = generator.Next(ArraySize);
                int swap = theArray[a];
                theArray[a] = theArray[b];
                theArray[b] = swap;
            }
        }

        public void FewValuedArray()
        {
            int k = ArraySize / 20;
            int h = 150 / k;
            for (int i = 0; i < ArraySize; ++i) theArray[i] = generator.Next(k) * h + 21;
        }
    }
}
