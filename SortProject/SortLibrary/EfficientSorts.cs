// EfficientSorts.cs
using System;

namespace SortLibrary
{
    /// <summary>
    /// Содержит эффективные алгоритмы сортировки с временной сложностью O(n log n)
    /// </summary>
    public class EfficientSorts
    {
        /// <summary>
        /// Сортирует массив методом слияния
        /// </summary>
        public static void MergeSort(int[] array)
        {
            // Базовый случай рекурсии
            if (array.Length <= 1) return;

            // Разделяем массив на две части
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            // Копируем элементы в подмассивы
            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            // Рекурсивно сортируем подмассивы
            MergeSort(left);
            MergeSort(right);

            // Сливаем отсортированные подмассивы
            Merge(array, left, right);
        }

        private static void Merge(int[] result, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            // Пока есть элементы в обоих массивах
            while (i < left.Length && j < right.Length)
            {
                // Выбираем меньший элемент
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            // Добиваем оставшиеся элементы
            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];
        }

        /// <summary>
        /// Быстрая сортировка Хоара
        /// </summary>
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                // Выбираем опорный элемент и разделяем массив
                int pivot = Partition(array, left, right);

                // Рекурсивно сортируем левую и правую части
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right]; // Опорный элемент
            int i = left - 1;        // Индекс для элементов ≤ pivot

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    // Перебрасываем элементы ≤ pivot влево
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            // Ставим опорный элемент на правильное место
            (array[i + 1], array[right]) = (array[right], array[i + 1]);
            return i + 1;
        }
    }
}