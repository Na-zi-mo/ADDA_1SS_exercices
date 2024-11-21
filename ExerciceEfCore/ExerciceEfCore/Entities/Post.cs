using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciceEfCore.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Blog Blog { get; set; }

        public override string ToString()
        {
            return $"PostId #{PostId}\nBlogId #{BlogId}\nTitre : {Title}\nContenu : {Content}";
        }
    }
}
