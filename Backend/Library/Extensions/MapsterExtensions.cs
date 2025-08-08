using DAL.Entities;
using DTO;
using Mapster;

namespace API.Extensions
{
    public static class MapsterExtensions
    {
        public static void RegisterMapping(this IApplicationBuilder app)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.AuthorBookMapping();
            config.AuthorMapping();
            config.BookGenreMapping();
            config.BookMapping();
        }

        private static void AuthorBookMapping(this TypeAdapterConfig config)
        {
            config.ForType<int, AuthorBook>()
                .MapWith(id => new AuthorBook() { AuthorId = id });
        }

        private static void AuthorMapping(this TypeAdapterConfig config)
        {
            config.ForType<Author, AuthorDto.List>()
                .Map(dest => dest.Name, src => $"{src.LastName} {src.FirstName} {src.Patronymic}");
        }

        private static void BookGenreMapping(this TypeAdapterConfig config)
        {
            config.ForType<int, BookGenre>()
                .MapWith(id => new BookGenre() { GenreId = id });
        }

        private static void BookMapping(this TypeAdapterConfig config)
        {
            config.ForType<BookDto.Upload, Book>()
                .Ignore(dest => dest.AlternativeTitles!)
                .Map(dest => dest.BookTypeId, src => int.Parse(src.BookTypeId))
                .Map(dest => dest.ISBN, src => string.IsNullOrWhiteSpace(src.ISBN) ? null : src.ISBN)
                .Map(dest => dest.PublisherId, src => int.Parse(src.PublisherId))
                .AfterMapping((src, dest) =>
                {
                    dest.AlternativeTitles = src.AlternativeTitles?
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(t => t.Trim())
                        .Select(str => new AlternativeTitle() { Title = str })
                        .ToList();
                })
                .AfterMapping((src, dest) =>
                {
                    dest.AuthorBooks = src.AuthorsId
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(t => int.Parse(t.Trim()))
                        .Adapt<List<AuthorBook>>();
                })
                .AfterMapping((src, dest) =>
                {
                    dest.BookGenres = src.GenresId
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(t => int.Parse(t.Trim()))
                        .Adapt<List<BookGenre>>();
                });
        }
    }
}
