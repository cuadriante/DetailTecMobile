using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailTecMobile.Models
{
    public class TrabajadorResponse
    {
        public string status { get; set; }
        public List<TrabajadorForGet> employees { get; set; }
    }
}
