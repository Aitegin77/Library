using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class BookGenre
    {
        [Key]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Key]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
