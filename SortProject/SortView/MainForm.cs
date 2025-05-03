using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using SortLibrary;
using System.Linq;

namespace SortView
{
    public partial class MainForm : Form
    {
        private Random random = new Random();
        private int sortCounter = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateRandomArray();
        }

        private void GenerateRandomArray()
        {
            string Length = textBox2.Text;
            string Words_min = textBox3.Text;
            string Words_max = textBox4.Text;
            int Length_int, Words_min_int, Words_max_int;

            if (!int.TryParse(Length, out Length_int) || !int.TryParse(Words_min, out Words_min_int) || !int.TryParse(Words_max, out Words_max_int))
            {
                richTextBox1.Text = "Ошибка: введите целые числа в оба поля";
                return;
            }

            if (Length_int <= -1000000 || Words_min_int <= -1000000 || Length_int > 1000000 || Words_min_int > 1000000 || Words_max_int <= -1000000 || Words_max_int > 1000000)
            {
                richTextBox1.Text = "Ошибка: числа должны быть от -1000000 до 1.000.000";
                return;
            }

            if (Words_max_int < Words_min_int)
            {
                richTextBox1.Text = "Ошибка: минимум не должен превышать мксимум";
                return;
            }

            int[] randomArray = new int[Length_int];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(Words_min_int, Words_max_int + 1);
            }

            richTextBox1.Text = string.Join(", ", randomArray);
        }

        private int[] ParseInputArray()
        {
            string inputText = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка: массив пуст";
                return null;
            }

            try
            {
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> numbers = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s.Trim(), out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        richTextBox2.Text = $"Ошибка: неверный формат числа '{s}'";
                        return null;
                    }
                }

                return numbers.ToArray();
            }
            catch
            {
                richTextBox2.Text = "Ошибка при разборе массива";
                return null;
            }
        }

        private void PerformSort(Action<int[]> sortAction, string sortName)
        {
            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            int[] arrayToSort = (int[])numbers.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            sortAction(arrayToSort);
            stopwatch.Stop();

            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";

            History.Instance.AddResult(sortCounter++, sortName, stopwatch.Elapsed);
        }

        // Обновленные обработчики кнопок с указанием названий сортировок:
        private void button3_Click(object sender, EventArgs e) => PerformSort(SimpleSorts.BubbleSort, "Сортировка пузырьком");
        private void button4_Click(object sender, EventArgs e) => PerformSort(SimpleSorts.InsertionSort, "Сортировка вставками");
        private void button5_Click(object sender, EventArgs e) => PerformSort(EfficientSorts.MergeSort, "Сортировка слиянием");
        private void button6_Click(object sender, EventArgs e) => PerformSort(arr => EfficientSorts.QuickSort(arr, 0, arr.Length - 1), "Быстрая сортировка");
        private void button2_Click(object sender, EventArgs e) => PerformSort(LinearSorts.CountingSort, "Сортировка подсчетом");

        private void button7_Click(object sender, EventArgs e)
        {
            // Получаем массив из ввода
            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            // Проверяем, что массив содержит ровно 2 вида чисел
            if (!ContainsOnlyTwoNumbers(numbers))
            {
                richTextBox2.Text = "Ошибка: массив должен содержать ровно 2 вида чисел!";
                return;
            }

            // Создаем копию для сортировки
            int[] arrayToSort = (int[])numbers.Clone();

            // Замеряем время выполнения сортировки
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Выполняем оптимизированную сортировку
            SortTwoNumberArray(arrayToSort);

            stopwatch.Stop();

            // Выводим результаты
            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
            History.Instance.AddResult(sortCounter++, "Сортировка 2 видов чисел", stopwatch.Elapsed);
        }

        // Эффективная сортировка массива с двумя видами чисел
        private void SortTwoNumberArray(int[] array)
        {
            if (array == null || array.Length < 2)
                return;

            // Находим два уникальных числа
            int firstNum = array[0];
            int secondNum = firstNum;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != firstNum)
                {
                    secondNum = array[i];
                    break;
                }
            }

            // Если все элементы одинаковые - выходим
            if (firstNum == secondNum)
                return;

            // Определяем порядок сортировки (по возрастанию)
            if (firstNum > secondNum)
            {
                int temp = firstNum;
                firstNum = secondNum;
                secondNum = temp;
            }

            // Разделение массива (аналог partition в QuickSort)
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                while (left < right && array[left] == firstNum)
                    left++;

                while (left < right && array[right] == secondNum)
                    right--;

                if (left < right)
                {
                    // Меняем местами
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
        }

        // Метод для проверки, что массив содержит ровно 2 вида чисел
        private bool ContainsOnlyTwoNumbers(int[] array)
        {
            if (array == null || array.Length == 0)
                return false;

            return array.Distinct().Count() == 2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            // Проверяем, что в массиве ровно 3 уникальных числа
            var uniqueNumbers = numbers.Distinct().ToArray();
            if (uniqueNumbers.Length != 3)
            {
                richTextBox2.Text = "Ошибка: массив должен содержать ровно 3 вида чисел!";
                return;
            }

            int[] arrayToSort = (int[])numbers.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();

            // Получаем 3 уникальных числа
            int low = uniqueNumbers.Min();
            int high = uniqueNumbers.Max();
            int mid = uniqueNumbers.First(x => x != low && x != high);

            // Сортируем по принципу голландского флага
            DutchFlagSort(arrayToSort, mid, high);

            stopwatch.Stop();

            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4} мс";
            History.Instance.AddResult(sortCounter++, "Сортировка 3 чисел", stopwatch.Elapsed);
        }

        // Реализация сортировки голландского флага для 3 чисел
        private static void DutchFlagSort(int[] arr, int midValue, int highValue)
        {
            int i = 0;    // Текущий элемент
            int j = 0;    // Граница для low элементов
            int k = arr.Length - 1; // Граница для high элементов

            while (i <= k)
            {
                if (arr[i] < midValue)
                {
                    Swap(ref arr[i], ref arr[j]);
                    j++;
                    i++;
                }
                else if (arr[i] > midValue)
                {
                    Swap(ref arr[i], ref arr[k]);
                    k--;
                }
                else
                {
                    i++;
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hogwarts form = new Hogwarts();
            form.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Reference().ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            History.Instance.ShowDialog();
        }
    }
}