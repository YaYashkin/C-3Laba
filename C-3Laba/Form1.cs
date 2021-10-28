using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_3Laba
{
    public partial class Form1 : Form
    {
        private void tb_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        public Form1()
        {
            InitializeComponent();
            txtFirst.KeyUp += tb_KeyUp;
            txtResult.ReadOnly = true;
            var measureItems = new string[]
            {
                "м/с",
                "км/ч",
                "узел",
                "мах"
            };
            cmbFirst.DataSource = new List<string>(measureItems);
            cmbSecond.DataSource = new List<string>(measureItems);
            cmbResult.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            //Используемые типы
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "м/с":
                    measureType = MeasureType.mc;
                    break;
                case "км/ч":
                    measureType = MeasureType.km;
                    break;
                case "узел":
                    measureType = MeasureType.yz;
                    break;
                case "мах":
                    measureType = MeasureType.max;
                    break;
                default:
                    measureType = MeasureType.mc;
                    break;
            }
            return measureType;
        }

        public void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirst);
                MeasureType secondType = GetMeasureType(cmbSecond);
                MeasureType resultType = GetMeasureType(cmbResult);

                var firstSpeed = new Speed(firstValue, firstType);
                var secondSpeed = new Speed(secondValue, secondType);

                Speed sumSpeed;
                //Выбор действия над числами
                switch(cmbOperation.Text)
                {
                    case "+":
                        sumSpeed = firstSpeed + secondSpeed; txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "-":
                        sumSpeed = firstSpeed - secondSpeed; txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "*":
                        sumSpeed = firstSpeed * secondSpeed; txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "/":
                        sumSpeed = firstSpeed / secondSpeed; txtResult.Text = sumSpeed.To(resultType).Verbose();
                        break;
                    case "=":
                        sravn(firstValue, secondValue);
                        break;
                    default:
                        sumSpeed = new Speed(0, MeasureType.mc);
                        break;
                }
                
            }
            catch (FormatException)
            {
                
            }
        }
        //Метод сравнения двух величин
        private void sravn(double firstValue, double secondValue)
        {
            double first = 0, second = 0;
            switch (cmbFirst.Text)
            {
                case "м/с":
                    first = firstValue;
                    break;
                case "км/ч":
                    first = firstValue * 0.2777777777777778;
                    break;
                case "узел":
                    first = firstValue * 0.5144444444403701;
                    break;
                case "мах":
                    first = firstValue * 295.0463999999687;
                    break;
            }
            switch (cmbSecond.Text)
            {
                case "м/с":
                    second = secondValue;
                    break;
                case "км/ч":
                    second = secondValue * 0.2777777777777778;
                    break;
                case "узел":
                    second = secondValue * 0.5144444444403701;
                    break;
                case "мах":
                    second = secondValue * 295.0463999999687;
                    break;
            }
            if (first > second)
            {
                l2.Text = "Результат сравнения: ";
                l3.Text = "Первое число больше второго";
                txtResult.Clear();
            }
            else if (first < second)
            {
                l2.Text = "Результат сравнения: ";
                l3.Text = "Второе число больше первого";
                txtResult.Clear();
            }
            else
            {
                l2.Text = "Результат сравнения: ";
                l3.Text = "Числа равны";
                txtResult.Clear();
            }
        }
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        //Очистка окон
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtFirst.Clear();
            this.txtSecond.Clear();
            this.txtResult.Clear();
        }
        //Открытие формы 2
        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Owner = this;
            F2.Show();
        }
    }
}
