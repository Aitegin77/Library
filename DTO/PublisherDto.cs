using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record PublisherDto
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
            [Required, DisplayName("Название"), MaxLength(120), DataType(DataType.Text)]
            public string Name { get; set; }

            [DisplayName("Адрес"), MaxLength(150), DataType(DataType.Text)]
            public string? Address { get; set; }

            [DisplayName("Контакты"), MaxLength(65), DataType(DataType.Text)]
            public string? Contacts { get; set; }

            [Required, DisplayName("Страна")]
            public int CountryId { get; set; }

            [DisplayName("Дополнительная информация"), MaxLength(250), DataType(DataType.MultilineText)]
            public string? ExtraInfo { get; set; }
        }

        public record Edit : Create { }
    }
}