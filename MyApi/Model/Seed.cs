using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class Seed
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var context = serviceProvider.GetRequiredService<MyApi.Model.Context.Context>();
      var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
      var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      context.Database.EnsureCreated();
      if (!context.Users.Any())
      {
        ApplicationUser user = new ApplicationUser()
        {
          UserName = "Admin",
          Email = "Admin@Gmail.com",
          SecurityStamp = Guid.NewGuid().ToString()
        };
        try
        {
           userManager.CreateAsync(user, "Administrator@123").Wait();
           roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
           userManager.AddToRoleAsync(user, "Admin").Wait();
        }
        catch (Exception ex)
        {
          throw;
        }

      }
    }
  }
}
