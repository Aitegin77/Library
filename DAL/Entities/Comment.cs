using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Required, MaxLength(500)]
        public string Content { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int? NumberPage { get; set; }
        public DateTime Date { get; set; }
    }
}
