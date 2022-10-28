using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class SucursalResponse
    {
        public string status { get; set; }
        public List<SucursalForGet> branches { get; set; }
    }
}
