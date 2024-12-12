using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Region
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Region region &&
                   Id == region.Id &&
                   Nom == region.Nom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nom);
        }

        public override string ToString() => Nom;
    }
}
