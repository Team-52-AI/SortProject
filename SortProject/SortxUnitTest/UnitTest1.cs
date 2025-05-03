using SortLibrary;
namespace SortxUnitTest
{
    public class UnitTest1
    {
        private readonly Random random = new Random();

        public int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = random.Next(-500000, 500000);
            return array;
        }

        public static IEnumerable<object[]> SortTestData()
        {
            yield return new object[] { new Action<int[]>(SimpleSorts.BubbleSort), 0 };
            yield return new object[] { new Action<int[]>(SimpleSorts.BubbleSort), 1 };
            yield return new object[] { new Action<int[]>(SimpleSorts.BubbleSort), 20 };
            yield return new object[] { new Action<int[]>(SimpleSorts.BubbleSort), 30 };
            yield return new object[] { new Action<int[]>(SimpleSorts.InsertionSort), 2 };
            yield return new object[] { new Action<int[]>(SimpleSorts.InsertionSort), 10 };
            yield return new object[] { new Action<int[]>(SimpleSorts.InsertionSort), 15 };
            yield return new object[] { new Action<int[]>(SimpleSorts.InsertionSort), 25 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 3 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 5 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 13 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 28 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 0 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 10 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 100 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 1000 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 10000 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 100000 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 1000000 };
            yield return new object[] { new Action<int[]>(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1)), 10000000 };
            yield return new object[] { new Action<int[]>(LinearSorts.CountingSort), 25 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 36 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 49 };
            yield return new object[] { new Action<int[]>(EfficientSorts.MergeSort), 64 };
        }

        [Theory]
        [MemberData(nameof(SortTestData))]
        public void ComparisonOrigSort(Action<int[]> sortAction, int size)
        {
            int[] array = GenerateRandomArray(size);
            int[] expected = array.ToArray();
            Array.Sort(expected);
            sortAction(array);
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new int[0], new int[0])]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        [InlineData(new int[] { 3, 3, 3, 3 }, new int[] { 3, 3, 3, 3 })]
        [InlineData(new int[] { 1, 1, 2, 2 }, new int[] { 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 2, 1, 1 }, new int[] { 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 1, 2, 1, 2 }, new int[] { 1, 1, 2, 2, 2 })]
        public void Test_Sort2(int[] a, int[] e)
        {
            LinearSorts.Sort2(a);
            Assert.Equal(e, a);
        }

        [Theory]
        [InlineData(new int[0], new int[0])]
        [InlineData(new[] { 1 }, new[] { 1 })]
        [InlineData(new int[] { 0, 0, 1, 1, 2, 2 }, new int[] { 0, 0, 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 2, 1, 1, 0, 0 }, new int[] { 0, 0, 1, 1, 2, 2 })]
        [InlineData(new int[] { 1, 0, 2, 1, 0, 2 }, new int[] { 0, 0, 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 2, 1, 1 }, new int[] { 1, 1, 2, 2 })]
        [InlineData(new int[] { 2, 1, 2, 1, 2 }, new int[] { 1, 1, 2, 2, 2 })]
        public void Test_DutchFlagSort(int[] a, int[] e)
        {
            LinearSorts.DutchFlagSort(a);
            Assert.Equal(e, a);
        }

        [Theory]
        [InlineData(new char[0], new char[0])]
        [InlineData(new[] { 'G' }, new[] { 'G' })]
        [InlineData(new[] { 'G', 'G', 'R', 'R', 'H', 'H', 'S', 'S' }, new[] { 'G', 'G', 'R', 'R', 'H', 'H', 'S', 'S' })]
        [InlineData(new[] { 'S', 'S', 'H', 'H', 'R', 'R', 'G', 'G' }, new[] { 'G', 'G', 'R', 'R', 'H', 'H', 'S', 'S' })]
        [InlineData(new[] { 'H', 'G' }, new[] { 'G', 'H' })]
        public void Test_SortHat(char[] a, char[] e)
        {
            LinearSorts.SortHat(a);
            Assert.Equal(e, a);
        }
    }
}