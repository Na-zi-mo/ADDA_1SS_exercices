using System.ComponentModel.DataAnnotations;

namespace JardinageWpf.Models
{
    public class Famille
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public override string ToString() => Nom;
    }
}
