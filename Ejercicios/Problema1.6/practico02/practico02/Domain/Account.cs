using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico02.Domain
{
    public class Account
    {
        public int IdCuenta { get; set; }
        public string Cbu { get; set; }
        public decimal Saldo { get; set; }
        public AccountType TipoDeCuenta { get; set; }
        public DateTime UltimoMovimiento { get; set; }

        public override string ToString()
        {
            return $"Id: {IdCuenta}, Cbu: {Cbu}, Saldo: {Saldo}, Tipo de Cuenta: {TipoDeCuenta}, Ultimo Movimiento: {UltimoMovimiento}";
        }

    }
}
