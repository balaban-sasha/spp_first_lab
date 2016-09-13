using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spp_first_lab;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Linq;

namespace UnitTestProject1
{
    public class TheEasiestBenchmark
    {
        Random random = new Random();
        int[] array ={ 3, 4, 5, 6, 2, 5, 1, 2, 3, 46, 7, 3, 3, 1, -23, -4, -32, -43, 32, -43, 42, -43, 321, 43, 32 };
        int[] array2= { 3, 4, 5, 6, 2, 5, 1, 2, 3, 46, 7, 3, 3, 1, -23, -4, -32, -43, 32, -43, 42, -43, 321, 43, 32 };
        [Benchmark(Description = "Test1")]
        public void Test1()
        {
            
            Program.OptimizedQuickSort QuickSort = new Program.OptimizedQuickSort();
            QuickSort.ToSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);   
        }

        [Benchmark(Description = "Test2")]
        public void Test2()
        {
            Program.QuickSort QuickSort = new Program.QuickSort();
            QuickSort.ToSort(array2, 0, array2.Length - 1);
            for (int i = 0; i < array2.Length; i++)
                array2[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array2, 0, array.Length - 1);
        }

    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOnReverseArray()
        {
            Program.QuickSort QuickSort = new Program.QuickSort();
            Random random = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
                array[i] = i * (-1);
            QuickSort.ToSort(array, 0, array.Length - 1);
            foreach (var temp in array)
                Console.Write("{0} ", temp);
        }
        [TestMethod]
        public void TestOnStandartWorkingOfQuickSort()
        {
            Program.QuickSort QuickSort = new Program.QuickSort();
            Random random = new Random();
            int[] array = { 5, 3, 4, 2, 1 };
            int[] array2 = { 1, 2, 3, 4, 5 };
            QuickSort.ToSort(array, 0, array.Length - 1);
            foreach (var temp in array)
                Console.Write("{0} ", temp);
            CollectionAssert.AreEqual(array2,array);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BenchmarkRunner.Run<TheEasiestBenchmark>();
        }

    }

}
