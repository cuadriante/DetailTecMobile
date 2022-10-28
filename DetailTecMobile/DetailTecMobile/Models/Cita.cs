using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class Cita
    {
        public string id { get; set; }
        public string cedulaCliente { get; set; }
        public string placaVehiculo { get; set; }
       public int IDSucursal { get; set; }
       public int tipoLavado { get; set; }
       public DateTime fecha { get; set; }
       public DateTime hora { get; set; }
       public string medioPago { get; set; }
       public List<string> idEmpleados { get; set; }

       public string estado { get; set; }
    }
}
