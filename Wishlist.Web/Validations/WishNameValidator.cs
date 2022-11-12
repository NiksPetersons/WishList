using WishList.Core.Models;
using Wishlist.Web.RequestModels;

namespace WishList.Core.Validations;

public class WishNameValidator : IWishValidator
{
    public bool IsValid(WishRequest wishRequest)
    {
        return !string.IsNullOrEmpty(wishRequest.Name);
    }
}