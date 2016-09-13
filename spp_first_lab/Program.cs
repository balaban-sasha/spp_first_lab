using System;
using System.Collections;

namespace spp_first_lab
{
  public class Program
  {
    private static void Main(string[] args)
    {
            Program.QuickSort quickSort = new Program.QuickSort();
            Random random = new Random();
            int numberOfElements;
            bool result = Int32.TryParse(Console.ReadLine(), out numberOfElements);
            if (result)
                if (numberOfElements > 0)
                {
                    int[] array=new int[numberOfElements];
                    for (int index = 0; index < array.Length; ++index)
                        array[index] = random.Next(-10000, 10000);
                    quickSort.ToSort(array, 0, array.Length - 1);
                    //foreach has been changed on for because it use more IL code
                    for (int index = 0; index < array.Length; ++index)
                        Console.Write("{0} ", (object)array[index]);
                    Console.ReadKey();
                }
    }

    public class QuickSort
    {
      private IComparer comparer = (IComparer) new Program.ClassForCompare();

      public void ToSort(int[] array, int left, int right)
      {
        int num = array[left + (right - left) / 2 + 1];
        int i = left;
        int j = right;
        while (i <= j)
        {
          while (comparer.Compare(array[i], num) == 1)
            ++i;
          while (comparer.Compare( array[j],  num) == -1)
            --j;
          if (i <= j)
          {
            Swap(array, i, j);
            i++;
            j--;
          }
        }
        if (comparer.Compare(i, right) == 1)
          ToSort(array, i, right);
        if (comparer.Compare( left, j) == 1)
          ToSort(array, left, j);
      }

      private void Swap(int[] array, int i, int j)
      {
        int num = array[i];
        array[i] = array[j];
        array[j] = num;
      }
    }
        public class OptimizedQuickSort
        {

            private IComparer comparer = (IComparer)new Program.ClassForCompare();

            public void ToSort(int[] array, int left, int right)
            {
                int num = array[left + (right - left) / 2 + 1];
                int index1 = left;
                int index2 = right;
                while (index1 <= index2)
                {
                    while (this.comparer.Compare((object)array[index1], (object)num) == 1)
                        ++index1;
                    while (this.comparer.Compare((object)array[index2], (object)num) == -1)
                        --index2;
                    if (index1 <= index2)
                    {
                        this.Swap(array, index1, index2);
                        ++index1;
                        --index2;
                    }
                }
                if (this.comparer.Compare((object)index1, (object)right) == 1)
                    this.ToSort(array, index1, right);
                if (this.comparer.Compare((object)left, (object)index2) != 1)
                    return;
                this.ToSort(array, left, index2);
            }

            private void Swap(int[] array, int i, int j)
            {
                int num = array[i];
                array[i] = array[j];
                array[j] = num;
            }
        }
        public class ClassForCompare : IComparer
    {
      int IComparer.Compare(object firstElement, object secondElement)
      {
        return new CaseInsensitiveComparer().Compare(secondElement, firstElement);
      }
    }
  }
}