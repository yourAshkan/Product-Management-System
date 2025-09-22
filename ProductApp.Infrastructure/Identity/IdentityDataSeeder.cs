using Microsoft.AspNetCore.Identity;

namespace ProductApp.Infrastructure.Identity;

public static class IdentityDataSeeder
{
    public static async Task SeedRoles(RoleManager<IdentityRole<int>> roleManager)
    {
        string[] roleNames = { "User", "Admin" };

        foreach(var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(roleName));
            }
        }
    }
}
