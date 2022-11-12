using WishList.Core.Models;

namespace Wishlist.Web.RequestModels;

public class UsersRequest
{
    public ICollection<User> Users { get; set; }
}