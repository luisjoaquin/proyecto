using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class inventario
    {
        int codigo;
        string nombre;
        int costo;
        int precio;
        int existencia;

        public int Codigo
        {
            set { this.codigo = value; }
            get { return this.codigo; }
        }
        public string Nombre
       {
           set { this.nombre = value; }
           get { return this.nombre; }
       }
        public int Precio
        {
            set { this.precio = value; }
            get { return this.codigo; }
        }
        public int Existencia
        {
            set { this.existencia = value; }
            get { return this.existencia; }
        }
        public int Costo
        {
            set { this.costo = value; }
            get { return this.costo; }
        }
    }
}
