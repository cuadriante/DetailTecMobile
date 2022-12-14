using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class TrabajadorForGet
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaInicio { get; set; }
        public int edad { get; set; }
        public string puesto { get; set; }
        public string frecuenciaPago { get; set; }
    }
}
