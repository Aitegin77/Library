using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> SignInAsync(AuthDto.Credentials credentials);
        public Task SignUpAsync(AuthDto.Registration registration);
        public Task SignOutAsync();
        public Task RequestPasswordResetAsync(string email);
        public Task ResetPasswordAsync(AuthDto.ResetPassword resetPassword);
    }
}
