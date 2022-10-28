using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class CitaResponse
    {
        public string status { get; set; }
        public List<CitaForGet> appointments { get; set; }
    }
}
