namespace ExerciceEfCore.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; } = new();

        public override string ToString()
        {
            return $"BlogId #{BlogId}, Url : {Url}\n============\n"
                + string.Join("\n============\n", Posts);
        }
    }
}
