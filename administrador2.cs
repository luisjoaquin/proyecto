using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace proyecto
{

    public partial class administrador2 : Form
    {

        int indice;
        public administrador2()
        {
            InitializeComponent();
        }
        List<producto> pro = new List<producto>();
        List<inventario> inve = new List<inventario>();

        private void button1_Click(object sender, EventArgs e)
        {
            string nombredelarchivo = "producto.txt";
            FileStream stream = new FileStream(nombredelarchivo, FileMode.Append, FileAccess.Write);
            StreamWriter escribir = new StreamWriter(stream);

            escribir.WriteLine(textBox1.Text);
            escribir.WriteLine(textBox2.Text);
            escribir.WriteLine(textBox3.Text);
            escribir.WriteLine(textBox4.Text);
            escribir.WriteLine(textBox5.Text);
            inventario tem = new inventario();
            tem.Codigo = Convert.ToInt16(textBox1.Text);
            tem.Nombre = textBox2.Text;
            tem.Costo = Convert.ToUInt16(textBox5.Text);
            tem.Precio = Convert.ToInt16(textBox3.Text);
            tem.Existencia = Convert.ToInt16(textBox4.Text);
            inve.Add(tem);

            escribir.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();



        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = inve;
            dataGridView1.Refresh();
        }

        private void administrador2_Load(object sender, EventArgs e)
        {
            string archivo = "producto.txt";
            FileStream leer = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader lectro = new StreamReader(leer);
            while (lectro.Peek() > -1)
            {
                inventario tem = new inventario();
                tem.Codigo = Convert.ToInt16(lectro.ReadLine());
                tem.Nombre = lectro.ReadLine();
                tem.Precio = Convert.ToInt32(lectro.ReadLine());
                tem.Existencia = Convert.ToInt32(lectro.ReadLine());
                tem.Costo = Convert.ToInt32(lectro.ReadLine());
                inve.Add(tem);

            }
            lectro.Close();
            for (int a = 0; a < inve.Count; a++)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = inve;
                dataGridView1.Refresh();
            }

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indice = dataGridView1.CurrentRow.Index;
            textBox1.Text = Convert.ToString(inve[indice].Codigo);
            textBox2.Text = inve[indice].Nombre;
            textBox3.Text = Convert.ToString(inve[indice].Precio);
            textBox4.Text = Convert.ToString(inve[indice].Existencia);
            textBox5.Text = Convert.ToString(inve[indice].Costo);


 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void button4_Click(object sender, EventArgs e)
        {

            inve[indice].Codigo = Convert.ToInt32 (textBox1.Text);
            inve[indice].Nombre = textBox2.Text;
            inve[indice].Precio = Convert.ToInt32 (textBox3.Text);
            inve[indice].Existencia = Convert.ToInt32(textBox4.Text);
            inve[indice].Costo = Convert.ToInt32(textBox5.Text);

            string fileName = "producto.txt";
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < inve.Count; i++)
            {

                writer.WriteLine(inve[i].Codigo);
                writer.WriteLine(inve[i].Nombre);
                writer.WriteLine(inve[i].Existencia);
                writer.WriteLine(inve[i].Precio);
                writer.WriteLine(inve[i].Costo);
            }

            //Cerrar el archivo
            writer.Close();


        }

    }
}

            
        
