using FluentAssertions;
using WishList.Core.Models;
using WishList.Core.UserOperations;

namespace WishList.UnitTests;

public class UserOperationTests
{
    [Fact]
    public void GetUserNames_GiveListOfUsers_ShouldReturnStringOfNames()
    {
        //Arrange
        var users = new List<User>
        {
            new()
            {
                Type = "user",
                Id = 150709,
                Name = "johnsmith",
                Email = "jsmith@example.com"
            },
            new()
            {
                Type = "user",
                Id = 150710,
                Name = "angelinasmith",
                Email = "asmith@example.com"
            },
            new()
            {
                Type = "user",
                Id = 150910,
                Name = "adamivanov",
                Email = "aivanov@another.org"
            }
        };

        //Act
        var userNames = UserNameGetter.GetUserNames(users);

        //Assert
        userNames.Should().Be("johnsmith, angelinasmith, adamivanov");
    }
}