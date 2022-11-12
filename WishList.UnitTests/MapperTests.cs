using AutoMapper;
using FluentAssertions;
using WishList.Core.Models;
using Wishlist.Web.AutoMapper;
using Wishlist.Web.RequestModels;

namespace WishList.UnitTests;

public class MapperTests
{
    private readonly IMapper _mapper;

    public MapperTests()
    {
        _mapper = AutoMapperConfig.MapperConfig();
    }

    [Fact]
    public void Mapper_FromWishRequestToWish_ShouldBeOfCorrectTypeAndValues()
    {
        //Arrange
        var name = "Test wish";
        var wishRequest = new WishRequest
        {
            Name = name
        };

        //Act
        var wish = _mapper.Map<Wish>(wishRequest);

        //Assert
        wish.Should().BeOfType<Wish>();
        wish.Name.Should().Be(name);
    }

    [Fact]
    public void Mapper_FromWishToWishRequest_ShouldBeOfCorrectTypeAndValues()
    {
        //Arrange
        var name = "Test wish";
        var id = 1;
        var wish = new Wish
        {
            Id = id,
            Name = name
        };

        //Act
        var wishRequest = _mapper.Map<WishRequest>(wish);

        //Assert
        wish.Should().BeOfType<Wish>();
        wish.Name.Should().Be(name);
        wish.Id.Should().Be(id);
    }
}