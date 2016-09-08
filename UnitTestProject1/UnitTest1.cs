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
        [Benchmark(Description = "Test1")]
        public void Test1()
        {
            Program.OptimizedQuickSort QuickSort = new Program.OptimizedQuickSort();
            Random random = new Random();
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);   
        }

        [Benchmark(Description = "Test2")]
        public void Test2()
        {
            Program.QuickSort QuickSort = new Program.QuickSort();
            Random random = new Random();
            int[] array = new int[100];
            for (int index = 0; index < array.Length; index++)
                array[index] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);
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
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10000, 10000);
            QuickSort.ToSort(array, 0, array.Length - 1);
            for (int index = 0; index < array.Length; ++index)
                Console.Write("{0} ", (object)array[index]);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BenchmarkRunner.Run<TheEasiestBenchmark>();
        }

    }

}
