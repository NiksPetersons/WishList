using WishList.Core.Models;

namespace Wishlist.Web.UserOperations;

public static class UserNameGetter
{
    public static string GetUserNames(ICollection<User> users)
    {
        var userNames = string.Join(", ", users.Select(x => x.Name));
        return userNames;
    }
}