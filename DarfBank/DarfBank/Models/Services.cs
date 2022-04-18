using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.Models
{
    internal class Services
    {
        public class Servicio
        {
            public string idServicio { get; set; }
            public string servicio { get; set; }
            public string idTipoServicio { get; set; }
        }

        public class lstServicios
        {
            public IList<Servicio> Servicios { get; set; }
        }
    }

    
}
