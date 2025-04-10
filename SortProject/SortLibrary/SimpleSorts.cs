using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Класс, содержащий простые методы сортировки с квадратичной сложностью O(n^2)
    /// </summary>
    public class SimpleSorts
    {
        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        public static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Меняем элементы местами
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        public static void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
