using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Core.UserOperations;
using Wishlist.Web.RequestModels;

namespace Wishlist.Web.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult NamesFromUserList(UsersRequest userList)
        {
            var userNames = UserNameGetter.GetUserNames(userList.Users);
            return Ok(userNames);
        }
    }
}
