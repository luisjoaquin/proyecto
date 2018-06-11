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
    public partial class vendedor : Form
    {
        public vendedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            if ((textBox1.Text =="p")  &&(textBox2.Text == "g"))
            {
                vendedor2 g = new vendedor2();
                g.Show();
            }
            else
            {
                Close();
            }
        }

        private void vendedor_Load(object sender, EventArgs e)
        {

        }
    }
}
