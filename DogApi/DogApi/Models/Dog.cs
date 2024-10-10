using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class Favourite
    {
    }

    public class Dog
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public IList<Race> breeds { get; set; }
        public Favourite favourite { get; set; }
    }


}
