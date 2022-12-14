using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class SucursalForGet
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string telefono { get; set; }
        public string idGerente { get; set; }
        public string nombreGerente { get; set; }
        public string apellidoGerente { get; set; }
        public DateTime? fechaApertura { get; set; }
        public DateTime? fechaInicioGerente { get; set; }
    }
}
