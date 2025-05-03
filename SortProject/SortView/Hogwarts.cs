using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SortLibrary;

namespace SortView
{
    public partial class Hogwarts : Form
    {
        public Hogwarts()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем длину массива из textBox2
                int arrayLength = int.Parse(textBox2.Text);

                // Проверяем, что длина положительная
                if (arrayLength <= 0)
                {
                    throw new ArgumentException("Длина массива должна быть положительным числом");
                }

                // Массив возможных элементов
                char[] possibleElements = { 'R', 'H', 'G', 'S' };
                Random random = new Random();

                // Генерируем массив
                string[] resultArray = new string[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    int randomIndex = random.Next(possibleElements.Length);
                    resultArray[i] = possibleElements[randomIndex].ToString();
                }

                // Выводим результат в richTextBox1
                richTextBox1.Text = string.Join(", ", resultArray);
            }
            catch (Exception ex)
            {
                // Выводим ошибку в richTextBox2
                richTextBox2.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем текст из richTextBox1
            string arrayText = richTextBox1.Text;

            // Удаляем пробелы (если есть) и разбиваем строку по запятым
            string[] elements = arrayText.Replace(" ", "").Split(',');

            try
            {
                // Проверяем, что массив не пустой
                if (elements.Length == 0 || string.IsNullOrEmpty(arrayText))
                {
                    throw new ArgumentException("Массив пуст или не был сгенерирован");
                }

                // Проверяем, что все элементы допустимы
                foreach (string element in elements)
                {
                    if (element.Length != 1 || (element[0] != 'R' && element[0] != 'H' && element[0] != 'G' && element[0] != 'S'))
                    {
                        throw new ArgumentException($"Недопустимый элемент в массиве: {element}");
                    }
                }

                // Преобразуем в char[]
                char[] charArray = elements.Select(s => s[0]).ToArray();

                // Замеряем время сортировки
                Stopwatch stopwatch = Stopwatch.StartNew();
                LinearSorts.SortHat(charArray);
                stopwatch.Stop();

                // Выводим отсортированный массив в richTextBox2
                richTextBox2.Text = string.Join(", ", charArray);

                // Выводим время выполнения в textBox1
                textBox1.Text = $"{stopwatch.Elapsed.TotalMilliseconds:F4}";

                // Добавляем запись в историю
                History.Instance.AddResult(sortCounter++, "Сортировка Хогвартса", stopwatch.Elapsed);
            }
            catch (Exception ex)
            {
                // Выводим ошибку в richTextBox2
                richTextBox2.Text = $"Ошибка: {ex.Message}";
            }
        }

        private int sortCounter = 1;
    }
}
