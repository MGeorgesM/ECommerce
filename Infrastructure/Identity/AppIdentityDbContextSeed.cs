using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Léna",
                    Email = "Lena@test.com",
                    UserName = "Lena@test.com",
                    Address = new Address
                    {
                        FirstName = "Léna",
                        LastName = "Mouawad",
                        Street = "St 10",
                        City = "Saint Naboria",
                        ZipCode = "889900"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }

    }
}