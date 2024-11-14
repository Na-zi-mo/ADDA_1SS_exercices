using System;

namespace JardinageWpf.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Nom { get; set; }

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
