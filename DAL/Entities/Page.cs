using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Page
    {
        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Key]
        public int NumberPage { get; set; }
        [MaxLength(45)]
        public string? Name { get; set; }
        [Required, MaxLength(250)]
        public string FileUrl { get; set; }
        public ICollection<Bookmark>? Bookmarks { get; set; }
    }
}
