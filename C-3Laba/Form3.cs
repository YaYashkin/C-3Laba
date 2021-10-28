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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //закрытие окна
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Окрас всех форм в жёлтый цвет
        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Yellow;
            FormCollection F = Application.OpenForms;
            Form2 f2 = (Form2)this.Owner;
            f2.clrY();
            F[0].BackColor = Color.Yellow;
        }
        //Окрас всех форм в зелёный цвет
        private void button3_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Lime;
            FormCollection F = Application.OpenForms;
            Form2 f2 = (Form2)this.Owner;
            f2.clrG();
            F[0].BackColor = Color.Lime;
        }
        //Окрас всех форм в синий цвет
        private void button4_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Aqua;
            Form2 f2 = (Form2)this.Owner;
            f2.clrA();
            FormCollection F = Application.OpenForms;
            F[0].BackColor = Color.Aqua;
        }
        //закрытие всех окон
        private void button5_Click(object sender, EventArgs e)
        {
            FormCollection F = Application.OpenForms;
            F[0].Close();
            Form2 f2 = new Form2();
            f2.close();
            this.Close();
        }
        //Окрас всех форм в цвет по умолчанию
        private void button6_Click(object sender, EventArgs e)
        {
            this.BackColor = DefaultBackColor;
            Form2 f2 = (Form2)this.Owner;
            f2.clrD();
            FormCollection F = Application.OpenForms;
            F[0].BackColor = DefaultBackColor;
        }
    }
}
