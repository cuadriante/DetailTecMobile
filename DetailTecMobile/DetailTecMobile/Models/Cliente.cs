using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DetailTecMobile.Models
{
    public class Cliente
    {
        [PrimaryKey]
        public string id { get; set; }
        [MaxLength(20)]
        public string nombre { get; set; }
        [MaxLength(20)]
        public string apellido1 { get; set; }
        [MaxLength(20)]
        public string apellido2 { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        [MaxLength(20)]
        public string password { get; set; }
        public int total { get; set; }
        public int utilizados { get; set; }
        public int actuales { get; set; }

        
    }
}
