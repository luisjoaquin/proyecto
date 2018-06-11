using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class detalles
    {
        string productos;
        int existencias;
        float precio;
        float total;
        public string Producto
        {
            set { this.productos = value; }
            get { return this.productos; }
        }
        public int Existencias
        {
            set { this.existencias = value; }
            get { return this.existencias; }
        }
        public float Precio
        {
            set { this.precio = value; }
            get { return this.precio; }
        }
        public float Total
        {
            set { this.total = value; }
            get { return this.total; }
        }
    }
}
