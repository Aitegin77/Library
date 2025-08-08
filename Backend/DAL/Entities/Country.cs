using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(60)]
        public string Name { get; set; }
        [Required, MaxLength(60)]
        public string EnglishName { get; set; }
        [Required, MaxLength(7)]
        public string ShortName { get; set; }
        [Required, MaxLength(120)]
        public string FlagUrl { get; set; }
        [Required, MaxLength(120)]
        public string GoogleMapsUrl { get; set; }
        public ICollection<Author>? Authors { get; set; }
        public ICollection<Publisher>? Publishers { get; set; }
    }
}
