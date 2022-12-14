using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class ClienteForGet
    {
        public string id { get; set; }
        public string usuario { get; set; } // Agregué este
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string email { get; set; }
        public List<string> telefonos { get; set; }
        public List<string> direcciones { get; set; }
        public int total { get; set; }
        public int utilizados { get; set; }
        public int actuales { get; set; }
    }
}
