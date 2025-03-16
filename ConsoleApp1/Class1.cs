using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Sorter<T> where T : IComparable<T>      //for any type
    {
        private T[] Array;

        public Sorter(T[] array)
        {
            Array = array;
        }

        public void Swap(ref T value1, ref T value2)
        {
            (value1, value2) = (value2, value1);
        }

        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        public T[] CombSort()
        {
            int length = Array.Length;
            int step = length - 1;

            while (step > 1)
            {
                for (int i = 0; i + step < length; i++)
                {
                    if (Array[i].CompareTo(Array[i + step]) > 0)
                    {
                        Swap(ref Array[i], ref Array[i + step]);
                    }
                }
                step = GetNextStep(step);
            }
            BubbleSort();
            return Array;
        }

        private void BubbleSort()
        {
            int length = Array.Length;
            for (int i = 1; i < length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < length - i; j++)
                {
                    if (Array[j].CompareTo(Array[j + 1]) > 0)
                    {
                        Swap(ref Array[j], ref Array[j + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        public T[] ShillSort()
        {
            int length = Array.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i++)
                {
                    T temp = Array[i];
                    int j = i;
                    while (j >= gap && Array[j - gap].CompareTo(temp) > 0)
                    {
                        Array[j] = Array[j - gap];
                        j -= gap;
                    }
                    Array[j] = temp;
                }
            }
            return Array;
        }

        public override string ToString()
        {
            return string.Join(" ", Array);
        }
    }
}
