using Microsoft.EntityFrameworkCore;
using WishList.DataBase;

namespace WishList.UnitTests.TestBase;

public class ServiceTestBase : IDisposable
{
    protected readonly WishListDbContext _context;

    public ServiceTestBase()
    {
        var options = new DbContextOptionsBuilder<WishListDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new WishListDbContext(options);

        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}