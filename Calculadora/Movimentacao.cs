using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Movimentacao
    {
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // C ou D
        public Decimal Valor { get; set; }
    }
}
