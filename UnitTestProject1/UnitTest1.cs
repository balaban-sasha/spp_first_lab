using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spp_first_lab;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.QuickSort QuickSort = new Program.QuickSort();
            Random random = new Random();
            int[] a = new int[100];
            for (int i = 0; i < a.Length; i++)
                a[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(a, 0, a.Length - 1);
            foreach (var temp in a)
                Console.Write("{0} ", temp);
        }

    }

}
