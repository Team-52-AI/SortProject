// LinearSorts.cs
using System;

namespace SortLibrary
{
    public class LinearSorts
    {
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;

            int min = array[0];
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }

            int[] count = new int[max - min + 1];

            for (int i = 0; i < array.Length; i++)
                count[array[i] - min]++;

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

        public static void Sort2(ref int a, ref int b)
        {
            if (a > b)
                Swap(ref a, ref b);
        }

        public static void DutchFlagSort(int[] array)
        {
            int low = 0;
            int mid = 0;
            int high = array.Length - 1;

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

        public static void SortHat(char[] students)
        {
            int n = students.Length;
            int g = 0;    // Граница для Гриффиндора
            int r = 0;    // Текущий индекс проверки
            int h = n - 1; // Граница для Хаффлпаффа
            int s = n - 1; // Граница для Слизерина

            while (r <= h)
            {
                char current = students[r];
                char opposite = students[h];

                if (current == 'R') // Рейвенкло сразу на место
                {
                    r++;
                    continue;
                }

                if (opposite == 'H') // Хаффлпафф в конец
                {
                    Swap(students, h, s);
                    h--;
                    s--;
                    continue;
                }

                if (current == 'G') // Гриффиндор в начало
                {
                    Swap(students, r, g);
                    g++;
                    r++;
                }
                else if (opposite == 'S') // Слизерин в конец
                {
                    Swap(students, h, s);
                    h--;
                    s--;
                }
                else if (current == 'H' && opposite == 'R')
                {
                    Swap(students, r, h);
                    r++;
                    h--;
                }
                else if (current == 'H' && opposite == 'G')
                {
                    Swap(students, r, h);
                    Swap(students, r, g);
                    r++;
                    g++;
                }
                else if (current == 'S' && opposite == 'R')
                {
                    Swap(students, r, h);
                    Swap(students, h, s);
                    h--;
                    s--;
                }
                else if (current == 'S' && opposite == 'G')
                {
                    Swap(students, r, h);
                    Swap(students, r, g);
                    Swap(students, h, s);
                    r++;
                    g++;
                    h--;
                    s--;
                }
                else
                {
                    r++;
                }
            }
        }

        private static void Swap(char[] array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}