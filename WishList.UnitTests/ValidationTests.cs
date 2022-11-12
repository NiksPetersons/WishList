using FluentAssertions;
using WishList.Core.Validations;
using Wishlist.Web.RequestModels;

namespace WishList.UnitTests;

public class ValidationTests
{
    private readonly IWishValidator _nameValidator;
    public ValidationTests()
    {
        _nameValidator = new WishNameValidator();
    }

    [Fact]
    public void IsValid_GiveCorrectData_ShouldBeTrue()
    {
        //Arrange
        var wishRequest = new WishRequest
        {
            Name = "Test wish"
        };

        //Act
        var validation = _nameValidator.IsValid(wishRequest);

        //Assert
        validation.Should().BeTrue();
    }

    [Fact]
    public void IsValid_GiveEmptyOrNullName_ShouldBeFalse()
    {
        //Arrange
        var emptyWishRequest = new WishRequest
        {
            Name = ""
        };
        var nullWishRequest = new WishRequest
        {
            Name = null
        };

        //Act
        var emptyValidation = _nameValidator.IsValid(emptyWishRequest);
        var nullValidation = _nameValidator.IsValid(nullWishRequest);

        //Assert
        emptyValidation.Should().BeFalse();
        nullValidation.Should().BeFalse();
    }
}