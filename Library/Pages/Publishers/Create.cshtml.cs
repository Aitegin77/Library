using BLL.Interfaces;
using Common.Redirects;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private ICountryService CountryService { get; }
        private IPublisherService PublisherService { get; }

        [BindProperty]
        public PublisherDto.Create Publisher { get; set; }

        public CreateModel(ICountryService countryService, IPublisherService publisherService)
        {
            CountryService = countryService;
            PublisherService = publisherService;
        }

        public async Task<IActionResult> OnGetCountries(string filter)
        {
            var countries = await CountryService.GetFilteredListAsync(filter);

            return new JsonResult(countries);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            await PublisherService.AddAsync(Publisher);

            return LibRedirect.ToMainPage();
        }
    }
}
