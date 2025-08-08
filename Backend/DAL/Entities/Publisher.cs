using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Address { get; set; }
        [MaxLength(65)]
        public string? Contacts { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [MaxLength(250)]
        public string? ExtraInfo { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
