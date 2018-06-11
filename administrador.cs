using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class administrador : Form
    {
        public administrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "h")&&(textBox1.Text =="g"))
            {
            administrador2 h = new administrador2();
            h.Show();
            }
            else
            {
                MessageBox.Show(" incorrecto");
                Close();
            }
        }
    }
}
