using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortLibrary;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { 5, 1, 4, 2, 8 }, new int[] { 1, 2, 4, 5, 8 })]
        public void Test_BubbleSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), SimpleSorts.BubbleSort(a).ToList()); }

        [DataTestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new int[] { 9, 12, 6, 15, 3 }, new[] { 3, 6, 9, 12, 15 })]
        [DataRow(new int[] { 7, 3, 7, 1, 3 }, new int[] { 1, 3, 3, 7, 7 })]
        [DataRow(new int[] { 42 }, new int[] { 42 })]
        public void Test_InsertionSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), SimpleSorts.InsertionSort(a).ToList()); }

        [DataTestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new int[] { 10, 20, 30, 40, 50 }, new int[] { 10, 20, 30, 40, 50 })]
        [DataRow(new int[] { 10000, 5000, 20000, 15000 }, new int[] { 5000, 10000, 15000, 20000 })]
        [DataRow(new int[] { -3, 5, -1, 0, 2 }, new int[] { -3, -1, 0, 2, 5 })]
        public void Test_MergeSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), EfficientSorts.MergeSort(a).ToList()); }

        [DataTestMethod]
        [DataRow(new int[0], new int[0])]
        [DataRow(new int[] { 100, 90, 80, 70, 60 }, new int[] { 60, 70, 80, 90, 100 })]
        [DataRow(new int[] { 0, 0, 0, 1, 0 }, new int[] { 0, 0, 0, 0, 1 })]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        public void Test_QuickSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), EfficientSorts.QuickSort(a, 0, a.Length-1).ToList()); }

        [DataTestMethod]
        [DataRow( new int[] { 100, 200, 150, 50, 75 }, new int[] { 50, 75, 100, 150, 200 })]
        [DataRow(new int[] { -100, -200, -50, -300 },new int[] { -300, -200, -100, -50 })]
        [DataRow(new int[] { 4, 2, 2, 8, 3, 3, 1 }, new int[] { 1, 2, 2, 3, 3, 4, 8 })]
        [DataRow(new int[] { 10, 5, 2, 7, 4 }, new int[] { 2, 4, 5, 7, 10 })]
        public void Test_CountingSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), LinearSorts.CountingSort(a).ToList()); }

        [DataTestMethod]
        [DataRow(1, 2, new int[] { 1, 2 })] 
        [DataRow(2, 1, new int[] { 1, 2 })]
        [DataRow(5, 5, new int[] { 5, 5 })]  
        [DataRow(-1, -2, new int[] { -2, -1 })]
        public void Test_Sort2(int a, int b, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), LinearSorts.Sort2(ref a, ref b).ToList()); }

        [DataTestMethod]
        [DataRow(new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 2, 1, 0 }, new int[] { 0, 1, 2 })]
        [DataRow(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [DataRow(new int[] { 1, 2, 0 }, new int[] { 0, 1, 2 })]
        public void Test_DutchFlagSort(int[] a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), LinearSorts.DutchFlagSort(a).ToList()); }

        //[DataTestMethod]
        //[DataRow(new int[] { 0 }, new int[] { 1, 0, 0, 0 })]
        //[DataRow(new int[] { 1 }, new int[] { 0, 1, 0, 0 })] 
        //[DataRow(new int[] { 2 }, new int[] { 0, 0, 1, 0 })] 
        //[DataRow(new int[] { 3 }, new int[] { 0, 0, 0, 1 })] 
        //[DataRow(new int[] { 0, 1, 2, 3 }, new int[] { 1, 1, 1, 1 })]
        //public void Test_HogwartsSort(int[] a, int[] expected)
        //{ CollectionAssert.AreEqual(expected.ToList(), LinearSorts.HogwartsSort(a).ToList()); }
    }
}
