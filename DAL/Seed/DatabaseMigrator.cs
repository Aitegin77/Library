using Common.Enums;
using DAL.Context;
using DAL.Entities;
using DAL.Entities.Identity;
using DAL.Services;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DAL.Seed
{
    public class DatabaseMigrator
    {
        public static async Task SeedDatabaseAsync(IServiceProvider appServiceProvider)
        {
            await using var scope = appServiceProvider.CreateAsyncScope();
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<DatabaseMigrator>>();

            try
            {
                var libraryDbContext = serviceProvider.GetRequiredService<LibraryDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

                await SeedAdminAsync(userManager, roleManager);
                await SeedCountriesAsync(libraryDbContext, logger);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Migration error. DB seed error");
            }
        }

        private static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await SeedRoleAsync(roleManager);

            if (!await userManager.Users.AnyAsync(a => a.UserName == "admin"))
            {
                var admin = new Admin()
                {
                    UserName = "admin",
                    NickName = "Admin",
                    RegistrationDate = DateTime.UtcNow,
                    LastLogIn = DateTime.UtcNow,
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+996705851577",
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(admin, "12qw!@QW");
                await userManager.AddToRoleAsync(admin, RoleType.Admin.ToString());
            }

            if (!await userManager.Users.AnyAsync(a => a.UserName == "default"))
            {
                var _default = new Admin()
                {
                    UserName = "default",
                    NickName = "Default",
                    RegistrationDate = DateTime.UtcNow,
                    LastLogIn = DateTime.UtcNow,
                    Email = "default@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+996705851577",
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(_default, "12qw!@QW");
                await userManager.AddToRoleAsync(_default, RoleType.Admin.ToString());
            }
        }

        private static async Task SeedRoleAsync(RoleManager<Role> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync(r => r.Name == RoleType.Admin.ToString()))
            {
                await roleManager.CreateAsync(new Role() { Name = RoleType.Admin.ToString() });
            }

            if (!await roleManager.Roles.AnyAsync(r => r.Name == RoleType.User.ToString()))
            {
                await roleManager.CreateAsync(new Role() { Name = RoleType.User.ToString() });
            }
        }

        private static async Task SeedCountriesAsync(LibraryDbContext libraryDbContext, ILogger logger)
        {
            try
            {
                if (await libraryDbContext.Countries.AnyAsync()) { return; }

                var response = await CountryService.GetCountriesAsync();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var countries = JsonSerializer.Deserialize<List<CountryDto.Http>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (countries?.FirstOrDefault()?.Name != null)
                    {
                        foreach (var country in countries)
                        {
                            var newCountry = new Country
                            {
                                Name = country.Translations.Rus.Common,
                                EnglishName = country.Name.Common,
                                ShortName = $"{country.Cca2.ToLower()}-{country.Cca2.ToUpper()}",
                                FlagUrl = country.Flags.Png,
                                GoogleMapsUrl = country.Maps.GoogleMaps
                            };

                            await libraryDbContext.Countries.AddAsync(newCountry);
                        }

                        await libraryDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        logger.LogCritical("Failed to deserialize countries");
                    }
                }
                else
                {
                    logger.LogCritical($"There are no countries, {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "System couldn't seed countries");
            }
        }
    }
}
