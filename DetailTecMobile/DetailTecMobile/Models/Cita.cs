using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class Cita
    {
        [PrimaryKey]
        public int id { get; set; }
        [MaxLength(8)]
        public string cedulaCliente { get; set; }
        [MaxLength(6)]
        public string placaVehiculo { get; set; }

        public int IDSucursal { get; set; }
        public int tipoLavado { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }

        public string medioPago { get; set; }

        //public int generada { get; set; }

        //public List<string> idEmpleados { get; set; }
    }
}
