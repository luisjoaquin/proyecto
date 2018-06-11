using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class producto
    {
        int  codigo;
        string nombre;
        int precio;
        int exitencia;
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
            get { return this.precio; }
        }
        public int Exitencia
        {
            set { this.exitencia = value; }
            get { return this.exitencia; }
        }
    }
}
