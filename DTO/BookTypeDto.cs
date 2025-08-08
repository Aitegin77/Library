using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record BookTypeDto
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
            [Required, DisplayName("Название"), MaxLength(50), DataType(DataType.Text)]
            public string Name { get; set; }
        }

        public record Edit : Create { }
    }
}
