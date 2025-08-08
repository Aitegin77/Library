using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required, MaxLength(45)]
        public string Name { get; set; }
        public ICollection<BookCollection>? BookCollections { get; set; }
    }
}
