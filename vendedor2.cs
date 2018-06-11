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
    public partial class vendedor2 : Form
    {
        public vendedor2()
        {
            InitializeComponent();
        }
        List<clientes> clie = new List<clientes>();
        List<inventario> inve = new List<inventario>();
        List<detalles> venta = new List<detalles>();

        private void button1_Click(object sender, EventArgs e)
        {
            string archivo = "clientes.txt";
            FileStream leer = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader lectro = new StreamReader(leer);
            while (lectro.Peek() > -1)
            {
               clientes tem = new clientes();
               tem.Nit = Convert.ToInt16(lectro.ReadLine());
                tem.Nombre = lectro.ReadLine();
                clie.Add(tem);

            }
            lectro.Close();
            for (int a = 0; a < clie.Count; a++)
            {
                if (textBox1.Text == Convert.ToString(clie[a].Nit))
                {
                    textBox2.Text = (clie[a].Nombre);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
          
                writer.WriteLine(textBox1.Text);
                writer.WriteLine(textBox2.Text);
                writer.Close();
                limpiar();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            
        }

        private void vendedor2_Load(object sender, EventArgs e)
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
                dataGridView1.Columns["costo"].Visible = false;

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indi = dataGridView1.CurrentRow.Index;
            int monto = Convert.ToInt32(textBox3.Text);
            if (monto > inve[indi].Existencia)
            {
                MessageBox.Show("no se puede ralizar transaccion ");
            }
            else
            {
                float total = monto * inve[indi].Precio;
                detalles temp = new detalles();
                temp.Producto = inve[indi].Nombre;
                temp.Precio = inve[indi].Precio;
                temp.Existencias = monto;
                inve[indi].Existencia = inve[indi].Existencia - monto;
                temp.Total = total;
                venta.Add(temp);
                actualizardaetalles();
                aproducto();
                calcualarsubtototal();

               
            }

        }
        public void aproducto()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = inve;
            dataGridView1.Refresh();
            dataGridView1.Columns["costo"].Visible = false;
        }
        public void actualizardaetalles()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = venta;
            dataGridView2.Refresh();
        }
        public void calcualarsubtototal()
        {
            float subtotal = 0;
            for (int x = 0; x < venta.Count; x++)
            {
                subtotal = subtotal + venta[x].Total;
            }
            label7.Text = Convert.ToString(subtotal);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float cambio = 0;
            float dinero = float.Parse(textBox4.Text);
            float subtotal = float.Parse(label7.Text);
            if (dinero < subtotal)
            {
                MessageBox.Show("no se puede realizar operaciones");
            }
            else
            {
                cambio = dinero - subtotal;
                label8.Text = Convert.ToString(cambio);
            }

            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizararchivoproducto();
            registrardeallesventa();
        }
        public void actualizararchivoproducto()
        {
            string nombredelarchivo = "producto.txt";
            FileStream stream = new FileStream(nombredelarchivo, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i< venta.Count; i++)
            {
                writer.WriteLine(inve[i].Codigo);
                writer.WriteLine(inve[i].Nombre);
                writer.WriteLine(inve[i].Existencia);
                writer.WriteLine(inve[i].Precio);
                writer.WriteLine(inve[i].Costo);
            }
            writer.Close();
        }
        public void registrardeallesventa()
        {
            string archivo = "detalle.txt";
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            //Generare un codigo aleatorio
            Random rnd = new Random();
            string codigoDeVenta = Convert.ToString(rnd.Next(999999999)); // me da un numero de 0 a 99999999 para que la probabildad sea poca de que me de un numero igual
            writer.WriteLine(codigoDeVenta);
            // si estos campos estan llenos procedo a guardar los datos
            for (int y = 0; y < venta.Count; y++)
            {
                writer.WriteLine(venta[y].Producto);
                writer.WriteLine(venta[y].Precio);
                writer.WriteLine(venta[y].Existencias);
                writer.WriteLine(venta[y].Total);
                
            }
            writer.WriteLine("-1");
        }
    }
  
}
