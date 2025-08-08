using DTO;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace API.Infrastructure
{
    internal static class CookieOptionsBuilder
    {
        internal static void Configure(CookieAuthenticationOptions options, IConfiguration configuration)
        {
            var settings = configuration.GetSection(nameof(AuthDto.CookieSettings)).Get<AuthDto.CookieSettings>();

            options.LoginPath = "/Account/Authorization";
            options.AccessDeniedPath = "/Error";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(settings!.ExpireTimeSpanMinutes);
            options.SlidingExpiration = settings.SlidingExpiration;
            options.Cookie = new CookieBuilder
            {
                HttpOnly = settings.HttpOnly,
                SecurePolicy = Enum.Parse<CookieSecurePolicy>(settings.SecurePolicy),
                SameSite = Enum.Parse<SameSiteMode>(settings.SameSite)
            };
        }

        //internal static JwtSecurityToken GetJwtSecurityToken(IEnumerable<Claim> claims, AuthDto.Jwt jwt)
        //{
        //    var utcNow = DateTime.UtcNow;
        //    var expires = utcNow.Add(TimeSpan.FromMinutes(jwt.AccessTokenLifeTimeInMinutes));
        //    var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.Key)),
        //                SecurityAlgorithms.HmacSha256Signature);

        //    return new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, utcNow, expires, signingCredentials);
        //}

        //internal static string Bearer() =>
        //    nameof(Bearer).ToLower();

        //internal static string Authorization() =>
        //    nameof(Authorization);
    }
}
