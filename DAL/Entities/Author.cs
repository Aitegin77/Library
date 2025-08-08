using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(25)]
        public string LastName { get; set; }
        [Required, MaxLength(20)]
        public string Patronymic { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        public DateOnly? DateOfDeath { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public string? Link { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
