using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Book
{
    public class ListModel : PageModel
    {
        private IBookService BookService { get; }

        public List<BookDto.List> Books { get; set; }

        public ListModel(IBookService bookService) =>
            BookService = bookService;

        public async Task OnGetAsync() =>
            Books = await BookService.GetListAsync();
    }
}
