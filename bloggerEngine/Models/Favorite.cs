namespace bloggerEngine.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}