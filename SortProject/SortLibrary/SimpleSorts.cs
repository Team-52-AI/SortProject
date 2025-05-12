// SimpleSorts.cs
namespace SortLibrary
{
    /// <summary>
    /// Содержит реализации простых алгоритмов сортировки с временной сложностью O(n²)
    /// </summary>
    public class SimpleSorts
    {
        /// <summary>
        /// Сортирует массив методом пузырька
        /// </summary>
        public static void BubbleSort(int[] array)
        {
            int n = array.Length;
            // Проходим по массиву n-1 раз
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false; // Флаг оптимизации

                // Каждый проход уменьшает диапазон на i элементов
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Сравниваем соседние элементы
                    if (array[j] > array[j + 1])
                    {
                        // Меняем элементы местами
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                }

                // Если обменов не было - массив отсортирован
                if (!swapped) break;
            }
        }

        /// <summary>
        /// Сортирует массив методом вставок
        /// </summary>
        public static void InsertionSort(int[] array)
        {
            int n = array.Length;
            // Начинаем со второго элемента
            for (int i = 1; i < n; i++)
            {
                int key = array[i]; // Текущий элемент для вставки
                int j = i - 1;     // Начало отсортированной части

                // Сдвигаем элементы больше key вправо
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                // Вставляем key в правильную позицию
                array[j + 1] = key;
            }
        }
    }
}