using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.Models
{
    public class Cuentas
    {
        public class Cuenta
        {
            public string idCuenta { get; set; }
            public string numero_cuenta { get; set; }
            public string balance { get; set; }
            public string idCliente { get; set; }
        }

        public class lstCuentas
        {
            public IList<Cuenta> cuentas { get; set; }
        }
    }
}
