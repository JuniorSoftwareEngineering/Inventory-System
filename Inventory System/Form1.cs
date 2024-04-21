using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста введите данные");

            }

            else if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                Main form = new Main();
                form.Show();
            }

            else 
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}
