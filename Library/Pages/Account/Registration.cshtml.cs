using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private IAuthService AuthService { get; init; }

        public RegistrationModel(IAuthService authService) => AuthService = authService;

        public async Task OnPost(AuthDto.Registration registration)
        {
            await AuthService.SignUpAsync(registration);
        }
    }
}
