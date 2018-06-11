using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class clientes
    {
        int nit;
        string nombre;
        int precio;
        int existencia;

        public int Nit
        {
            set { this.nit = value; }
            get { return this.nit; }
        }
        public string Nombre
       {
           set { this.nombre = value; }
           get { return this.nombre; }
       }
    }
}
