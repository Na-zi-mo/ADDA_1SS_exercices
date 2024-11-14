using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JardinageWpf.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Plante> Plantes { get; set; }

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