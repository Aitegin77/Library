using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record AuthDto
    {
        public record Credentials
        {
            [Required]
            public string Login { get; init; }

            [Required]
            public string Password { get; init; }
        }

        public record Registration : Credentials
        {
            [Required]
            public string NickName { get; init; }

            [Required]
            public string ConfirmPassword { get; init; }

            [Required]
            public string Email { get; init; }

            public string? ProfilePicture { get; init; }
        }

        public record ResetPassword
        {
            [Required]
            public string Email { get; init; }

            [Required]
            public string Token { get; init; }

            [Required]
            public string NewPassword { get; init; }

            [Required]
            public string ConfirmPassword { get; init; }
        }

        public record CookieSettings
        {
            /// <summary>
            /// The duration (in minutes) for which the cookie will be valid before expiration.
            /// </summary>
            public int ExpireTimeSpanMinutes { get; init; }

            /// <summary>
            /// Indicates whether the cookie's expiration time should be extended on each request.
            /// </summary>
            public bool SlidingExpiration { get; init; }

            /// <summary>
            /// Indicates whether the cookie is accessible only by the server and not by JavaScript.
            /// </summary>
            public bool HttpOnly { get; init; }

            /// <summary>
            /// Defines the security policy for sending the cookie (e.g., always over HTTPS).
            /// </summary>
            public string SecurePolicy { get; init; }

            /// <summary>
            /// Defines the SameSite policy for the cookie (e.g., restricts cross-site requests).
            /// </summary>
            public string SameSite { get; init; }
        }
    }
}
