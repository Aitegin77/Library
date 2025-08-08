using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DTO
{
    public record BookDto
    {
        public record Key
        {
            public int Id { get; set; }
        }

        public record List : Key
        {
            public string Name { get; set; }
            public List<AuthorDto.List> Authors { get; set; }
            public List<GenreDto.List> Genres { get; set; }
            public float Rating { get; set; }
            public string CoverImageUrl { get; set; }
        }

        public record Upload
        {
            [Required, DisplayName("Название"), MaxLength(250), DataType(DataType.Text)]
            public string Title { get; set; }

            [DisplayName("Альтернативные названия"), DataType(DataType.Text)]
            public string? AlternativeTitles { get; set; }

            [Required, DisplayName("Дата публикации"), DataType(DataType.Date)]
            public DateOnly PublishedDate { get; set; }

            [DisplayName("ISBN"), MaxLength(13), DataType(DataType.Text)]
            public string? ISBN { get; set; }
            public string AuthorsId { get; set; }
            public string PublisherId { get; set; }
            public string GenresId { get; set; }
            public string BookTypeId { get; set; }

            [DisplayName("Обложка книги"), DataType(DataType.Upload)]
            public IFormFile? CoverImage { get; set; }

            [Required, DisplayName("Описание"), MaxLength(500), DataType(DataType.MultilineText)]
            public string Description { get; set; }

            [Required, DisplayName("Страницы книги"), DataType(DataType.Upload)]
            public Stream Pages { get; set; }
        }

        public record Edit : Upload { }
    }
}