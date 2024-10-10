using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DogApi.Models
{
    public class Race
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string bred_for { get; set; }
        public string breed_group { get; set; }
        public string life_span { get; set; }
        public string temperament { get; set; }
        public string reference_image_id { get; set; }
        public string origin { get; set; }
        public string country_code { get; set; }

        public override string ToString()
        {
            return name ?? "";
        }
    }
}
