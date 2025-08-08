using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
