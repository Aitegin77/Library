using API.Infrastructure;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Services;
using DAL.Context;
using DAL.Entities.Identity;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    internal static class IServiceCollectionExtension
    {
        internal static void RegisterConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        /*internal static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => CookieBuilder.SetParameters(options, configuration));
        }*/

        internal static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<LibraryDbContext>()
            .AddDefaultTokenProviders();
            //.AddGoogle();

            services.ConfigureApplicationCookie(options => CookieOptionsBuilder.Configure(options, configuration));
        }

        internal static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<LibraryDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IBookTypeService, BookTypeService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPublisherService, PublisherService>();
        }

        internal static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookTypeRepository, BookTypeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
        }
    }
}