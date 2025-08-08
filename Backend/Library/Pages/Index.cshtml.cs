using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages
{
    public class IndexModel : PageModel
    {
        private IAuthService AuthService { get; init; }

        public IndexModel(IAuthService authService)
        {
            AuthService = authService;
        }

        public void OnGet()
        {

        }
    }
}
