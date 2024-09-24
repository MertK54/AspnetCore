using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;
public static class IdentitySeedData
{
    private const string adminUserName = "admin";
    private const string adminPasword = "Admin_123";
    public static async void IdentityTestUser(IApplicationBuilder app)
    {
        var context =  app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();
        if(context.Database.GetAppliedMigrations().Any())
        {
            context.Database.Migrate();
        }
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var user = await userManager.FindByNameAsync(adminUserName);
        if(user == null)
        {
            user = new AppUser {
                FullName = "Mert Kezer",
                UserName = adminUserName,
                Email = "kezermert@gmail.com",
                PhoneNumber = "55555"
            };
            await userManager.CreateAsync(user,adminPasword);
        };
    }
}