using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WishList.Core.Models;

namespace WishList.DataBase;

public interface IWishListDbContext
{
    DbSet<Wish> Wishes { get; set; }
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    int SaveChanges();
}