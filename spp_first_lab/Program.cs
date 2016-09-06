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
            public void ToSort(int[] a, int v, int length)
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
