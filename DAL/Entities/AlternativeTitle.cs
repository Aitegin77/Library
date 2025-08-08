using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class AlternativeTitle
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
    }
}
