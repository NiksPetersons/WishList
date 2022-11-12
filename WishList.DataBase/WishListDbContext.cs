using Microsoft.EntityFrameworkCore;
using WishList.Core.Models;

namespace WishList.DataBase;

public class WishListDbContext : DbContext, IWishListDbContext
{
    public WishListDbContext(DbContextOptions<WishListDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseSerialColumns();
    }

    public DbSet<Wish> Wishes { get; set; }
}