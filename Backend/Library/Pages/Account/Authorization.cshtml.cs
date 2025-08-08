using BLL.Interfaces;
using Common.Redirects;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Account
{
    public class AuthorizationModel : PageModel
    {
        private IAuthService AuthService { get; init; }

        public AuthorizationModel(IAuthService authService) =>
            AuthService = authService;

        public async Task<IActionResult> OnPostSignIn(AuthDto.Credentials credentials)
        {
            var success = await AuthService.SignInAsync(credentials);
            if (!success)
                return new UnauthorizedResult();

            return LibRedirect.ToMainPage();
        }

        public async Task<IActionResult> OnPostSignOut()
        {
            await AuthService.SignOutAsync();

            return LibRedirect.ToMainPage();
        }
    }
}
