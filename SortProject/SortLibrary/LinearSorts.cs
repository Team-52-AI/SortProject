using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibrary
{
    /// <summary>
    /// Класс, содержащий сортировки линейной сложности и специализированные методы
    /// </summary>
    public class LinearSorts
    {
        /// <summary>
        /// Сортировка подсчетом (Bucket sort для небольших диапазонов)
        /// </summary>
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            int min = array[0];
            int max = array[0];

            // Находим диапазон значений
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }

            // Создаем массив подсчета
            int[] count = new int[max - min + 1];

            // Заполняем массив подсчета
            for (int i = 0; i < array.Length; i++)
                count[array[i] - min]++;

            // Восстанавливаем отсортированный массив
            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    array[index++] = i + min;
                    count[i]--;
                }
            }
        }

        /// <summary>
        /// Сортировка 2 элементов
        /// </summary>
        public static void Sort2(ref int a, ref int b)
        {
            if (a > b)
                Swap(ref a, ref b);
        }

        /// <summary>
        /// Голландский флаг (сортировка 3 элементов)
        /// </summary>
        public static void DutchFlagSort(int[] array)
        {
            int low = 0;
            int mid = 0;
            int high = array.Length - 1;

            // Предполагаем, что средний элемент (pivot) = 1
            while (mid <= high)
            {
                switch (array[mid])
                {
                    case 0:
                        Swap(ref array[low], ref array[mid]);
                        low++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        Swap(ref array[mid], ref array[high]);
                        high--;
                        break;
                }
            }
        }

        /// <summary>
        /// Сортировка 4 элементов (Хогвартс)
        /// </summary>
        public static void HogwartsSort(int[] houses)
        {
            // Предполагаем значения: 0 - Гриффиндор, 1 - Слизерин, 2 - Когтевран, 3 - Пуффендуй
            int[] count = new int[4];

            // Подсчет количества студентов каждого факультета
            foreach (int house in houses)
                count[house]++;

            // Заполняем массив в порядке факультетов
            int index = 0;
            for (int house = 0; house < 4; house++)
            {
                while (count[house] > 0)
                {
                    houses[index++] = house;
                    count[house]--;
                }
            }
        }


        /// <summary>
        /// Вспомогательная функция для обмена элементов
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
