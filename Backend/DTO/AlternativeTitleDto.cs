using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record AlternativeTitleDto
    {
        public record Key
        {
            public int Id { get; set; }
        }

        public record List : Key
        {
            public string Title { get; set; }
        }

        public record Create
        {
            [Required, DisplayName("Название"), MaxLength(250), DataType(DataType.Text)]
            public string Title { get; set; }

            public int BookId { get; set; }
        }

        public record Edit : Create { }
    }
}
