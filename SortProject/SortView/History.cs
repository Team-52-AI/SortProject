using System;
using System.Windows.Forms;

namespace SortView
{
    public partial class History : Form
    {
        private static History instance;

        public static History Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new History();
                    instance.InitializeGridView();
                }
                return instance;
            }
        }

        private History()
        {
            InitializeComponent();
        }

        private void InitializeGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Number", "№");
            dataGridView1.Columns.Add("SortName", "Тип сортировки");
            dataGridView1.Columns.Add("Time", "Время (мс)");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Настройка ширины столбцов (опционально)
            dataGridView1.Columns["Number"].Width = 50;
            dataGridView1.Columns["SortName"].Width = 150;
            dataGridView1.Columns["Time"].Width = 100;
        }

        public void AddResult(int sortNumber, string sortName, TimeSpan duration)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => AddResult(sortNumber, sortName, duration)));
                return;
            }

            dataGridView1.Rows.Add(sortNumber, sortName, $"{duration.TotalMilliseconds:F4}");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}