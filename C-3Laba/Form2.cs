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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Вывод сообщения о задании
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скорость заданная в виде пары (значение, тип), допустимые типы: м/с, км/ч, узел, мах " +
                "\nсложение" +
                "\nвычитание" +
                "\nумножение на число" +
                "\nсравнение двух скоростей" +
                "\nвывод значения в любом типе", "Задание");
        }
        //Открытие формы 1
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Owner = this;
            this.Close();
        }
        //Открытие формы 3
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Owner = this;
            F3.Show();
        }
        //окрас формы в жёлтый цвет
        public void clrY()
        {
            this.BackColor = Color.Yellow;
        }
        //окрас формы в зелёный цвет
        public void clrG()
        {
            this.BackColor = Color.Lime;
        }
        //окрас формы в синий цвет
        public void clrA()
        {
            this.BackColor = Color.Aqua;
        }
        //закрытие окон
        public void close()
        {
            this.Close();
        }
        //окрас формы в цвет по умолчанию
        public void clrD()
        {
            this.BackColor = DefaultBackColor;
        }
    }
}
