using BLL.Interfaces;
using DAL.Entities.Identity;
using DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<User> UserManager { get; }
        private SignInManager<User> SignInManager { get; }

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<bool> SignInAsync(AuthDto.Credentials credentials)
        {
            var user = await UserManager.FindByNameAsync(credentials.Login);

            if (user == null || !await UserManager.CheckPasswordAsync(user, credentials.Password))
                return false;

            await SignInManager.SignInAsync(user, isPersistent: true);

            return true;
        }

        public async Task SignUpAsync(AuthDto.Registration registration)
        {
            /*var user = new User { UserName = register.Login, Email = register.Email };
            var result = await UserManager.CreateAsync(user, register.Password);
            if (!result.Succeeded) return new BadRequestObjectResult(result.Errors);

            await SignInManager.SignInAsync(user, isPersistent: false);*/
        }

        public async Task SignOutAsync()
        {
            await SignInManager.SignOutAsync();
        }

        public async Task RequestPasswordResetAsync(string email)
        {
            /*var user = await UserManager.FindByEmailAsync(email);
            if (user == null) return new NotFoundResult();

            var token = await UserManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://yourapp.com/reset-password?email={email}&token={token}";
            await EmailService.SendEmailAsync(email, "Сброс пароля", $"Ссылка для сброса пароля: {resetLink}");*/
        }

        public async Task ResetPasswordAsync(AuthDto.ResetPassword resetPassword)
        {
            /*var user = await UserManager.FindByEmailAsync(resetPassword.Email);
            if (user == null) return new NotFoundResult();

            var result = await UserManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);
            if (!result.Succeeded) return new BadRequestObjectResult(result.Errors);*/
        }
    }
}