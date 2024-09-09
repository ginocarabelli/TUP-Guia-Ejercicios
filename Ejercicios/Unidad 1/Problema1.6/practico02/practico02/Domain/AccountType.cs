using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico02.Domain
{
    public class AccountType
    {
        public int IdTipoCuenta { get; set; }
        public string TipoDeCuenta { get; set; }
        public override string ToString()
        {
            return TipoDeCuenta;
        }
    }
}
