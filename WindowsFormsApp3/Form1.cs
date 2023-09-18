using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private int monthCode;
        private int yearCode;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var date = DateTime.Parse(textBox1.Text);

                Dictionary<int, string> map = new Dictionary<int, string>()
                {
                    {0, "Суббота" },
                    {1, "Воскресенье" },
                    {2, "Понедельник" },
                    {3, "Вторник" },
                    {4, "Среда" },
                    {5, "Четверг" },
                    {6, "Пятница" }
                };

                switch (date.Month)
                {
                    case 1:
                        monthCode = 1;
                        break;
                    case 2:
                        monthCode = 4;
                        break;
                    case 3:
                        monthCode = 4;
                        break;
                    case 4:
                        monthCode = 0;
                        break;
                    case 5:
                        monthCode = 2;
                        break;
                    case 6:
                        monthCode = 5;
                        break;
                    case 7:
                        monthCode = 0;
                        break;
                    case 8:
                        monthCode = 3;
                        break;
                    case 9:
                        monthCode = 6;
                        break;
                    case 10:
                        monthCode = 1;
                        break;
                    case 11:
                        monthCode = 4;
                        break;
                    case 12:
                        monthCode = 6;
                        break;
                    default:
                        break;
                }
                int temp = Convert.ToInt32(date.Year.ToString().Substring(date.Year.ToString().Length - 2)); //последние 2 цифры года
                yearCode = (6 + temp + temp / 4) % 7; //код года

                int result = (date.Day + monthCode + yearCode) % 7;

                MessageBox.Show($"День недели: {map[result]}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите дату в виде dd.mm.yyyy!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}