using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JardinageWpf.Models
{
    [Index(nameof(Nom), IsUnique = true)]
    public class Famille
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public override string ToString() => Nom;
    }
}