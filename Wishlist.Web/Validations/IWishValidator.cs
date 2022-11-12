using WishList.Core.Models;
using Wishlist.Web.RequestModels;

namespace WishList.Core.Validations;

public interface IWishValidator
{
    bool IsValid(WishRequest wishRequest);
}