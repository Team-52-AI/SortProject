using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using SortLibrary;

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
            if (textBox3.Text != "2")
            {
                richTextBox2.Text = "Для этой сортировки укажите 2 в поле 'Количество элементов'";
                return;
            }

            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            int[] arrayToSort = (int[])numbers.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            LinearSorts.Sort2(0, 1);
            stopwatch.Stop();

            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
            History.Instance.AddResult(sortCounter++, "Сортировка 2 элементов", stopwatch.Elapsed);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "3")
            {
                richTextBox2.Text = "Для этой сортировки укажите 3 в поле 'Количество элементов'";
                return;
            }

            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            int[] arrayToSort = (int[])numbers.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            LinearSorts.DutchFlagSort(arrayToSort);
            stopwatch.Stop();

            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
            History.Instance.AddResult(sortCounter++, "Голландский флаг", stopwatch.Elapsed);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "4")
            {
                richTextBox2.Text = "Для этой сортировки укажите 4 в поле 'Количество элементов'";
                return;
            }

            int[] numbers = ParseInputArray();
            if (numbers == null) return;

            int[] arrayToSort = (int[])numbers.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            LinearSorts.HogwartsSort(arrayToSort);
            stopwatch.Stop();

            richTextBox2.Text = string.Join(", ", arrayToSort);
            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
            History.Instance.AddResult(sortCounter++, "Хогвартс сортировка", stopwatch.Elapsed);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Reference().ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            History.Instance.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}