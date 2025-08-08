using BLL.Interfaces;
using Common.Redirects;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Genres
{
    public class CreateModel : PageModel
    {
        private IGenreService GenreService { get; set; }

        [BindProperty]
        public GenreDto.Create Genre { get; set; }

        public CreateModel(IGenreService genreService) =>
            GenreService = genreService;

        public void OnGet() { }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            await GenreService.AddAsync(Genre);

            return LibRedirect.ToMainPage();
        }
    }
}
