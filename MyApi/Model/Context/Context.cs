using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model.Context
{
  public class Context : IdentityDbContext<ApplicationUser>
  {
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
    public DbSet<Adverts> Adverts { get; set; }
    public DbSet<Bids> Bids { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Trademark> Trademarks { get; set; }
    public DbSet<Models> Models { get; set; }
    public DbSet<Messages> Messages { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Images> Images { get; set; }
  }
}
