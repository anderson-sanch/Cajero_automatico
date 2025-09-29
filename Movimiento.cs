using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero_automatico
{
    internal class Movimiento
    {
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Movimiento(string documento, string tipo, decimal monto) 
        {
            Documento = documento;
            Tipo = tipo;
            Monto = monto;
            Fecha = DateTime.Now;
        }
    }
}
