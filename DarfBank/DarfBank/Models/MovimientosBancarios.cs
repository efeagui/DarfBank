using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.Models
{
    public class MovimientosBancarios
    {
        public class MovimientoBancario
        {
            public string idMovimiento { get; set; }
            public string idTipoMovimiento { get; set; }
            public string fecha_movimiento { get; set; }
            public string idCuenta { get; set; }
            public string valor { get; set; }
            public string valorLps { get; set; }
            public string concepto { get; set; }
            public string fecha_hora { get; set; }
            public string idCliente { get; set; }
        }

        public class lstMovimientosBancarios
        {
            public IList<MovimientoBancario> MovimientoBancario { get; set; }
        }
    }
}
