using FluentAssertions;
using WishList.Core.Models;
using WishList.Services;
using WishList.UnitTests.TestBase;

namespace WishList.UnitTests;

public class WishServiceTests : ServiceTestBase
{
    private readonly IWishService _service;
    private readonly Wish _defaultWish;
    public WishServiceTests()
    {
        _service = new WishService(_context);
        _defaultWish = new Wish
        {
            Name = "Test wish"
        };
    }

    [Fact]
    public void Create_ShouldCreateAndAddWishToDatabase()
    {
        //Act
        _service.Create(_defaultWish);

        //Assert
        _context.Wishes.Count().Should().Be(1);
    }

    [Fact]
    public void Delete_ShouldDeleteWishFromDataBase()
    {
        //Act
        _context.Wishes.Add(_defaultWish);
        _context.SaveChanges();
        _service.Delete(_defaultWish);

        //Assert
        _context.Wishes.Count().Should().Be(0);
    }

    [Fact]
    public void Update_ShouldUpdateExistingWishInDataBase()
    {
        //Arrange
        var newName = "New Name";
        _context.Wishes.Add(_defaultWish);
        _context.SaveChanges();
        _defaultWish.Name = newName;

        //Act

        _service.Update(_defaultWish);

        //Assert
        _context.Wishes.First().Name.Should().Be(newName);
    }

    [Fact]
    public void GetById_ShouldReturnWishById()
    {
        //Arrange
        _context.Wishes.Add(_defaultWish);
        _context.SaveChanges();

        //Act
        var wish = _service.GetById<Wish>(1);

        //Assert
        wish.Should().Be(_defaultWish);
    }

    [Fact]
    public void GetAllWishes_ShouldReturnAllWishesInDataBase()
    {
        //Arrange
        var wish2 = new Wish
        {
            Name = "Test wish 2"
        };
        _context.Wishes.Add(_defaultWish);
        _context.Wishes.Add(wish2);
        _context.SaveChanges();

        //Act
        var wishes = _service.GetAll<Wish>();

        //Assert
        wishes.Count.Should().Be(2);
    }
}