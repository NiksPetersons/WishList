using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Services;

namespace Wishlist.Web.Controllers
{
    [Route("wishlist")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private readonly IWishService _service;

        public WishController(IWishService service)
        {
            _service = service;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddWish(Wish wish)
        {
            _service.Create(wish);

            return Created("", wish);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteWish(int id)
        {
            var wish = _service.GetById<Wish>(id);
            _service.Delete(wish);

            return Ok();
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateWish(int id, Wish wish)
        {
            var originalWish = _service.GetById<Wish>(id);
            originalWish.Name = wish.Name;
            _service.Update(originalWish);

            return Ok(originalWish);
        }

        [HttpGet]
        [Route("wish/{id}")]
        public IActionResult GetWishById(int id)
        {
            var wish = _service.GetById<Wish>(id);

            return Ok(wish);
        }

        [HttpGet]
        [Route("wishes")]
        public IActionResult GetAllWishes()
        {
            var wishes = _service.GetAll<Wish>();

            return Ok(wishes);
        }
    }
}
