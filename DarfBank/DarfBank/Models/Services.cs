using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.Models
{
    internal class Services
    {
        public int idServicio { get; set; }
        public String Servicio { get; set; }
        public String numero_cuenta { get; set; }
        public String idTipoServicio { get; set; }
        public String idCliente { get; set; }
    }
}
