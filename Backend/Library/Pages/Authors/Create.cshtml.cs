using BLL.Interfaces;
using Common.Redirects;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private IAuthorService AuthorService { get; }
        private ICountryService CountryService { get; }

        [BindProperty]
        public AuthorDto.Create Author { get; set; }

        public CreateModel(IAuthorService authorService, ICountryService countryService)
        {
            AuthorService = authorService;
            CountryService = countryService;
        }

        public async Task<IActionResult> OnGetCountries(string filter)
        {
            var countries = await CountryService.GetFilteredListAsync(filter);

            return new JsonResult(countries);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            await AuthorService.AddAsync(Author);

            return LibRedirect.ToMainPage();
        }
    }
}
