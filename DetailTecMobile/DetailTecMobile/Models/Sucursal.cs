using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class Sucursal
    {
        [PrimaryKey]
        public int id { get; set; }

        [MaxLength(50)]
        public string name { get; set; }
    }
}
