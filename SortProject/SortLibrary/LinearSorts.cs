// LinearSorts.cs
using System;

namespace SortLibrary
{
    /// <summary>
    /// Содержит алгоритмы сортировки с линейной временной сложностью
    /// </summary>
    public class LinearSorts
    {
        /// <summary>
        /// Сортировка подсчётом для целых чисел
        /// </summary>
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            // Находим диапазон значений
            int min = array[0];
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                min = Math.Min(min, array[i]);
                max = Math.Max(max, array[i]);
            }

            // Создаем массив для подсчета
            int[] count = new int[max - min + 1];

            // Заполняем счетчики
            foreach (int num in array)
                count[num - min]++;

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
        /// Сортировка голландского флага для трёх цветов
        /// </summary>
        public static void DutchFlagSort(int[] array)
        {
            int low = 0;        // Верхняя граница 0
            int mid = 0;         // Текущий элемент
            int high = array.Length - 1; // Нижняя граница 2

            while (mid <= high)
            {
                switch (array[mid])
                {
                    case 0:
                        // Перемещаем 0 в начало
                        (array[low], array[mid]) = (array[mid], array[low]);
                        low++;
                        mid++;
                        break;
                    case 1:
                        // 1 остается на месте
                        mid++;
                        break;
                    case 2:
                        // Перемещаем 2 в конец
                        (array[mid], array[high]) = (array[high], array[mid]);
                        high--;
                        break;
                }
            }
        }

        /// <summary>
        /// Сортировка для распределения по факультетам Хогвартса
        /// </summary>
        public static void SortHat(char[] students)
        {
            int n = students.Length;
            int g = 0;    // Граница Гриффиндора
            int r = 0;    // Текущая позиция
            int h = n - 1; // Граница Хаффлпаффа
            int s = n - 1; // Граница Слизерина

            // Основной цикл обработки
            while (r <= h)
            {
                char current = students[r];
                char opposite = students[h];

                // Обработка Рейвенкло
                if (current == 'R')
                {
                    r++;
                    continue;
                }

                // Обработка Хаффлпаффа
                if (opposite == 'H')
                {
                    Swap(students, h--, s--);
                    continue;
                }

                // Основная логика перестановок
                if (current == 'G')
                {
                    Swap(students, r++, g++);
                }
                else if (opposite == 'S')
                {
                    Swap(students, h--, s--);
                }
                else
                {
                    // Сложные случаи перестановок
                    if (current == 'H' && opposite == 'R')
                    {
                        Swap(students, r++, h--);
                    }
                    else if (current == 'H' && opposite == 'G')
                    {
                        Swap(students, r, h);
                        Swap(students, r++, g++);
                    }
                    else
                    {
                        r++;
                    }
                }
            }
        }

        // Вспомогательный метод для обмена элементов
        private static void Swap(char[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}