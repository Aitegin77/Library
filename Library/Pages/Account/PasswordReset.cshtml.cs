using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Pages.Account
{
    public class PasswordResetModel : PageModel
    {
        private IAuthService AuthService { get; init; }

        public PasswordResetModel(IAuthService authService) => AuthService = authService;

        public async Task OnPost(AuthDto.ResetPassword resetPassword)
        {
            await AuthService.ResetPasswordAsync(resetPassword);
        }
    }
}
