namespace ExerciceEfCore.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public override string ToString()
        {
            return $"PostId #{PostId}\nBlogId #{BlogId}\nTitre : {Title}\nContenu : {Content}";
        }
    }
}
