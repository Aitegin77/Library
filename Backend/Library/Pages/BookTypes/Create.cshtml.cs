using BLL.Interfaces;
using Common.Redirects;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.BookTypes
{
    public class CreateModel : PageModel
    {
        private IBookTypeService BookTypeService { get; set; }

        [BindProperty]
        public BookTypeDto.Create BookType { get; set; }

        public CreateModel(IBookTypeService bookTypeService) =>
            BookTypeService = bookTypeService;

        public void OnGet() { }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            await BookTypeService.AddAsync(BookType);

            return LibRedirect.ToMainPage();
        }
    }
}