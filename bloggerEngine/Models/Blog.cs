namespace bloggerEngine.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string imgUrl { get; set; }// = "https://placehold.it"
        public bool? Published { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}