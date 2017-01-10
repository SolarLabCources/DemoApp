namespace BusinessLogic.Objects
{
    /// <summary>
    /// Filtering parameters for posts
    /// </summary>
    public class PostFilter
    {
        public int? PostId { get; set; }
        public string Title { get; set; }
    }
}