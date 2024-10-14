using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Models
{
    public class Detection
    {
        public string language { get; set; }
        public bool isReliable { get; set; }
        public double confidence { get; set; }
    }
}
