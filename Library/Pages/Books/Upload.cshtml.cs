using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Book
{
    [Authorize]
    public class UploadModel : PageModel
    {
        private IAuthorService AuthorService { get; }
        private IBookService BookService { get; }
        private IBookTypeService BookTypeService { get; }
        private IFileService FileService { get; }
        private IGenreService GenreService { get; }
        private IPublisherService PublisherService { get; }
        public List<AuthorDto.List> Authors { get; private set; }
        public List<BookTypeDto.List> BookTypes { get; private set; }
        public List<GenreDto.List> Genres { get; private set; }
        public List<PublisherDto.List> Publishers { get; private set; }

        [BindProperty]
        public BookDto.Upload Book { get; set; }

        public UploadModel(IAuthorService authorService, IBookService bookService,
            IBookTypeService bookTypeService, IFileService fileService, 
            IGenreService genreService, IPublisherService publisherService)
        {
            AuthorService = authorService;
            BookService = bookService;
            BookTypeService = bookTypeService;
            FileService = fileService;
            GenreService = genreService;
            PublisherService = publisherService;
        }

        public async Task<IActionResult> OnGetAuthors(string filter)
        {
            var authors = await AuthorService.GetFilteredListAsync(filter);

            return new JsonResult(authors);
        }

        public async Task<IActionResult> OnGetBookTypes(string filter)
        {
            var bookTypes = await BookTypeService.GetFilteredListAsync(filter);

            return new JsonResult(bookTypes);
        }

        public async Task<IActionResult> OnGetGenres(string filter)
        {
            var genres = await GenreService.GetFilteredListAsync(filter);

            return new JsonResult(genres);
        }

        public async Task<IActionResult> OnGetPublishers(string filter)
        {
            var publishers = await PublisherService.GetFilteredListAsync(filter);

            return new JsonResult(publishers);
        }

        public async Task OnPostUploadAsync()
        {
            Book.Pages = await FileService.GetStreamFromRequestAsync(Request, $"{nameof(Book)}.{nameof(Book.Pages)}");

            await BookService.UploadAsync(Book);
        }
    }
}