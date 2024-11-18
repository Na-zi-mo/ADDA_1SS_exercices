using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExerciceEfCore.Entities
{
    [Index(nameof(Url), IsUnique = true)]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string Url { get; set; }

        public List<Post> Posts { get; set; } = new();

        public override string ToString()
        {
            return $"BlogId #{BlogId}, Url : {Url}\n============\n"
                + string.Join("\n============\n", Posts);
        }
    }
}
