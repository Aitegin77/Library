using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Bookmark
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int BookId { get; set; }
        public int NumberPage { get; set; }
        public Page Page { get; set; }
    }
}
