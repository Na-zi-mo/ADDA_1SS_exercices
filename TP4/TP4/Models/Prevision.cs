using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP4.Models
{
    public class Prevision
    {
        public string city_name { get; set; }
        public string country_code { get; set; }
        public IList<Data> data { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string state_code { get; set; }
        public string timezone { get; set; }
    }
}
