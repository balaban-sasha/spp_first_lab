﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spp_first_lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickSort = new QuickSort();
            Random random = new Random();
            int numberOfElements;
            bool result = Int32.TryParse(Console.ReadLine(), out numberOfElements);
            if (result)
                if (numberOfElements >= 0)
                {
                    int[] array = new int[numberOfElements];
                    for (int i = 0; i < array.Length; i++)
                        array[i] = random.Next(-10000, 10000);
                    quickSort.ToSort(array, 0, array.Length - 1);
                    foreach (var temp in array)
                        Console.Write("{0} ", temp);
                    Console.ReadKey();
                }
        }

        public class QuickSort
        {
            IComparer comparer = new ClassForCompare();
            public void ToSort(int[] array, int left, int right)
            {
                int middleElement = array[left + (right - left) / 2];
                int i = left;
                int j = right;
                while(i<=j)
                {
                    while (comparer.Compare(array[i], middleElement) == (1))
                        i++;
                    while (comparer.Compare(array[j], middleElement) == (-1))
                        j--;
                    if(i <= j)
                    {
                        Swap(array, i, j);
                        i++;
                        j--;
                    }
                }
                if (comparer.Compare(i, right) == 1)
                    ToSort(array, i, right);
                if (comparer.Compare(left, j) == 1)
                    ToSort(array, left, j);
            }

            private void Swap(int[] array, int i, int j)
            {
                int tempElement = array[i];
                array[i] = array[j];
                array[j] = tempElement;
            }
        }
        public class ClassForCompare:IComparer
        {
            int IComparer.Compare(Object firstElement,Object secondElement)
            {
                return ((new CaseInsensitiveComparer()).Compare(secondElement, firstElement));
            }
        }
    }
}
