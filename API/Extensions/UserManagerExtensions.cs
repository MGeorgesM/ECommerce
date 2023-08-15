using System.Security.Claims;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalIncludeAddress(this UserManager<AppUser> userManager,
            ClaimsPrincipal claimsPrincipal)
            {
                var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
                return await userManager.Users.Include(x => x.Address).FirstOrDefaultAsync<AppUser>(x => x.Email == email);
            }

        public static async Task<AppUser> FindUserByClaimsPrinciple(this UserManager<AppUser> userManager,
            ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}