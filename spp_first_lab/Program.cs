using System;
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
        }

        public class QuickSort
        {
            IComparer comparer = new ClassForCompare();
            public void ToSort(int[] array, int left, int right)
            {
                int middleElement = array[left + (right - left) / 2];
                int i = left;
                int j = right;
                while(comparer.Compare(i,j)!=(-1))
                {
                    while (comparer.Compare(array[i], middleElement) == 1)
                        i++;
                    while (comparer.Compare(array[j], middleElement) == (-1))
                        j--;
                    if(comparer.Compare(i,j)!=(-1))
                    {
                        Swap(array, i, j);
                        i++;
                        j++;
                    }
                }
                if (comparer.Compare(i, right) == 1)
                    ToSort(array, i, right);
                if (comparer.Compare(left, j) == 1)
                    ToSort(array, left, j);
                throw new NotImplementedException();
            }

            private void Swap(int[] array, int i, int j)
            {
                throw new NotImplementedException();
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
