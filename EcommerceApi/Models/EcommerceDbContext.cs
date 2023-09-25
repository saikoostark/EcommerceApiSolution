using Microsoft.EntityFrameworkCore;
using EcommerceApi.Utils;

namespace EcommerceApi.Models;

public class EcommerceDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<ProductCategory> ProductCategorys { get; set; }


    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> optionsBuilder) : base(optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        var salt1 = Hasher.GenerateSalt();
        var pass1 = "Ben1000";
        var hashed1 = Hasher.GenerateHash(pass1, salt1);

        var salt2 = Hasher.GenerateSalt();
        var pass2 = "Ben123";
        var hashed2 = Hasher.GenerateHash(pass2, salt2);
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                ID = 1,
                UserName = "saikoo10",
                Email = "saikoo@gmail.com",
                Salt = salt1,
                HashedPassword = hashed1,
                Phone = "+201125001709",
                Address = "rgregrgrjgire",
                Role = "AdminUser"
            }, new User()
            {
                ID = 2,
                UserName = "saikoo123",
                Email = "saikoo@gmail.com",
                Salt = salt2,
                HashedPassword = hashed2,
                Phone = "+201125001709",
                Address = "rgregrgrjgire",
                Role = "RegularUser"
            }

        );
    }


}