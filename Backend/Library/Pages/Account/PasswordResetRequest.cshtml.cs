using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Account
{
    public class PasswordResetRequestModel : PageModel
    {
        private IAuthService AuthService { get; init; }

        public PasswordResetRequestModel(IAuthService authService) => AuthService = authService;

        public async Task OnPost(string email)
        {
            await AuthService.RequestPasswordResetAsync(email);
        }
    }
}
