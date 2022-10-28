using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class LavadoResponse
    {
        public string status { get; set; }
        public List<LavadoForGet> washingTypes { get; set; }
    }
}
