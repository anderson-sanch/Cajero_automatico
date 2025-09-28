using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero_automatico
{
    internal class Usuario
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Clave { get; set; }
        public decimal Saldo { get; set; }

        public Usuario(string nombre, string documento, string clave, decimal saldo = 0) 
        {
            Nombre = nombre;
            Documento = documento;
            Clave = clave;
            Saldo = saldo;
        }
    }
}
