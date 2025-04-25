using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortLibrary;

namespace SortView
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Random random = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            string Length = textBox2.Text;
            string Words = textBox3.Text;
            int Length_int = 0;
            int Words_int = 0;

            try
            {
                Length_int = Convert.ToInt32(Length);
                Words_int = Convert.ToInt32(Words);
            }
            catch
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            if ((Length_int < 0 || Length_int > 1000000) || (Words_int < 0 || Words_int > 1000000))
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            // Генерируем массив из 100 случайных чисел от 0 до Length
            int[] randomArray = new int [Length_int];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(0, Words_int);
            }

            // Преобразуем массив в строку с элементами через запятую и выыводим его
            richTextBox1.Text = string.Join(", ", randomArray);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Получаем текст из RichTextBox1
            string inputText = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            int[] numbers;

            try
            {
                // Разделяем строку по запятым и удаляем возможные пробелы
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем лишние пробелы у каждого элемента
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = elements[i].Trim();
                }

                List<int> numbersList = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s, out int num))
                    {
                        numbersList.Add(num);
                    }
                }

                numbers = numbersList.ToArray();
            }
            catch (Exception ex)
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            SimpleSorts.BubbleSort(numbers);

            richTextBox2.Text = string.Join(", ", numbers);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            SimpleSorts.BubbleSort(numbers);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получаем текст из RichTextBox1
            string inputText = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            int[] numbers;

            try
            {
                // Разделяем строку по запятым и удаляем возможные пробелы
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем лишние пробелы у каждого элемента
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = elements[i].Trim();
                }

                List<int> numbersList = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s, out int num))
                    {
                        numbersList.Add(num);
                    }
                }

                numbers = numbersList.ToArray();
            }
            catch (Exception ex)
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            SimpleSorts.BubbleSort(numbers);

            richTextBox2.Text = string.Join(", ", numbers);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            SimpleSorts.InsertionSort(numbers);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Получаем текст из RichTextBox1
            string inputText = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            int[] numbers;

            try
            {
                // Разделяем строку по запятым и удаляем возможные пробелы
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем лишние пробелы у каждого элемента
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = elements[i].Trim();
                }

                List<int> numbersList = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s, out int num))
                    {
                        numbersList.Add(num);
                    }
                }

                numbers = numbersList.ToArray();
            }
            catch (Exception ex)
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            SimpleSorts.BubbleSort(numbers);

            richTextBox2.Text = string.Join(", ", numbers);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            EfficientSorts.MergeSort(numbers);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Получаем текст из RichTextBox1
            string inputText = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            int[] numbers;

            try
            {
                // Разделяем строку по запятым и удаляем возможные пробелы
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем лишние пробелы у каждого элемента
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = elements[i].Trim();
                }

                List<int> numbersList = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s, out int num))
                    {
                        numbersList.Add(num);
                    }
                }

                numbers = numbersList.ToArray();
            }
            catch (Exception ex)
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            SimpleSorts.BubbleSort(numbers);

            richTextBox2.Text = string.Join(", ", numbers);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            EfficientSorts.QuickSort(numbers, 0, (numbers.Length / 2));
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 1;

            string Length = textBox2.Text;
            string Words = textBox3.Text;
            int Length_int = 0;
            int Words_int = 0;

            if (Words != "2")
            {
                richTextBox2.Text = "Ошибка, для сортировки '2 элемента' в поле 'Количество неповторяющихся элементов' укажите 2";
                return;
            }

            try
            {
                Length_int = Convert.ToInt32(Length);
                Words_int = Convert.ToInt32(Words);
            }
            catch
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            if ((Length_int < 0 || Length_int > 1000000) || (Words_int < 0 || Words_int > 1000000))
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            // Генерируем массив из 100 случайных чисел от 0 до Length
            int[] randomArray = new int[Length_int];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(0, Words_int);
            }

            // Преобразуем массив в строку с элементами через запятую и выыводим его
            richTextBox1.Text = string.Join(", ", randomArray);

            SimpleSorts.BubbleSort(randomArray);

            richTextBox2.Text = string.Join(", ", randomArray);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            LinearSorts.Sort2(a, b);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string Length = textBox2.Text;
            string Words = textBox3.Text;
            int Length_int = 0;
            int Words_int = 0;

            if (Words != "3")
            {
                richTextBox2.Text = "Ошибка, для сортировки 'Флаг' в поле 'Количество неповторяющихся элементов' укажите 3";
                return;
            }

            try
            {
                Length_int = Convert.ToInt32(Length);
                Words_int = Convert.ToInt32(Words);
            }
            catch
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            if ((Length_int < 0 || Length_int > 1000000) || (Words_int < 0 || Words_int > 1000000))
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            // Генерируем массив из 100 случайных чисел от 0 до Length
            int[] randomArray = new int[Length_int];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(0, Words_int);
            }

            // Преобразуем массив в строку с элементами через запятую и выыводим его
            richTextBox1.Text = string.Join(", ", randomArray);

            SimpleSorts.BubbleSort(randomArray);

            richTextBox2.Text = string.Join(", ", randomArray);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            LinearSorts.DutchFlagSort(randomArray);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Length = textBox2.Text;
            string Words = textBox3.Text;
            int Length_int = 0;
            int Words_int = 0;

            if (Words != "4")
            {
                richTextBox2.Text = "Ошибка, для сортировки 'Хогвартс' в поле 'Количество неповторяющихся элементов' укажите 4";
                return;
            }

            try
            {
                Length_int = Convert.ToInt32(Length);
                Words_int = Convert.ToInt32(Words);
            }
            catch
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            if ((Length_int < 0 || Length_int > 1000000) || (Words_int < 0 || Words_int > 1000000))
            {
                richTextBox1.Text = "Ошибка, введите целое положительное число, не большее, чем 1.000.000, в поля: количество элементов и количество неповторяющихся элементов";
                return;
            }

            // Генерируем массив из 100 случайных чисел от 0 до Length
            int[] randomArray = new int[Length_int];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(0, Words_int);
            }

            // Преобразуем массив в строку с элементами через запятую и выыводим его
            richTextBox1.Text = string.Join(", ", randomArray);

            SimpleSorts.BubbleSort(randomArray);

            richTextBox2.Text = string.Join(", ", randomArray);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            LinearSorts.HogwartsSort(randomArray);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем текст из RichTextBox1
            string inputText = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            int[] numbers;

            try
            {
                // Разделяем строку по запятым и удаляем возможные пробелы
                string[] elements = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем лишние пробелы у каждого элемента
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = elements[i].Trim();
                }

                List<int> numbersList = new List<int>();

                foreach (string s in elements)
                {
                    if (int.TryParse(s, out int num))
                    {
                        numbersList.Add(num);
                    }
                }

                numbers = numbersList.ToArray();
            }
            catch (Exception ex)
            {
                richTextBox2.Text = "Ошибка, введите элементы массива через запятую!";
                return;
            }

            SimpleSorts.BubbleSort(numbers);

            richTextBox2.Text = string.Join(", ", numbers);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            LinearSorts.CountingSort(numbers);
            stopwatch.Stop();

            textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Reference form = new Reference();
            form.ShowDialog();
        }
    }
}
