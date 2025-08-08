using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record AuthorDto
    {
        public record Key
        {
            public int Id { get; set; }
        }

        public record List : Key
        {
            public string Name { get; set; }
        }

        public record Create
        {
            [Required, DisplayName("Имя"), StringLength(20, MinimumLength = 2), DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required, DisplayName("Фамилия"), StringLength(25, MinimumLength = 2), DataType(DataType.Text)]
            public string LastName { get; set; }

            [Required, DisplayName("Отчество"), StringLength(20, MinimumLength = 2), DataType(DataType.Text)]
            public string Patronymic { get; set; }

            [Required, DisplayName("Дата рождения"), DataType(DataType.Date)]
            public DateOnly DateOfBirth { get; set; }

            [DisplayName("Дата смерти"), DataType(DataType.Date)]
            public DateOnly? DateOfDeath { get; set; }
            public int CountryId { get; set; }

            [DisplayName("Ссылка на автора"), DataType(DataType.Url)]
            public string? Link { get; set; }
        }

        public record Edit : Create { }
    }
}
