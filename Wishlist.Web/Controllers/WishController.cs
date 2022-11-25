using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Web.RequestModels;
using WishList.Core.Models;
using WishList.Core.Validations;
using WishList.Services;

namespace Wishlist.Web.Controllers
{
    [Route("wishlist")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private readonly IWishService _service;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IWishValidator> _validators;

        public WishController(IWishService service, IMapper mapper, IEnumerable<IWishValidator> validators)
        {
            _service = service;
            _mapper = mapper;
            _validators = validators;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddWish(WishRequest wishRequest)
        {
            if (!_validators.Any(x => x.IsValid(wishRequest)))
            {
                return BadRequest("Name cannot be null or empty");
            }

            var wish = _mapper.Map<Wish>(wishRequest);
            _service.Create(wish);
            var uri = $"{Request.Scheme}://{Request.Host}/wishlist/wish/{wish.Id}";


            return Created(uri, wishRequest);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteWish(int id)
        {
            var wish = _service.GetById<Wish>(id);

            if (wish == null)
            {
                return NotFound("Wish with id of " + id + " does not exist");
            }

            _service.Delete(wish);

            return Ok();
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateWish(int id, WishRequest wishRequest)
        {
            if (!_validators.Any(x => x.IsValid(wishRequest)))
            {
                return BadRequest();
            }

            var originalWish = _service.GetById<Wish>(id);

            if (originalWish == null)
            {
                return NotFound("Wish with id of " + id + " does not exist");
            }

            originalWish.Name = wishRequest.Name;
            _service.Update(originalWish);
            wishRequest = _mapper.Map<WishRequest>(originalWish);

            return Ok(wishRequest);
        }

        [HttpGet]
        [Route("wish/{id}")]
        public IActionResult GetWishById(int id)
        {
            var wish = _service.GetById<Wish>(id);

            if (wish == null)
            {
                return NotFound("Wish with id of " + id + " does not exist");
            }

            var request = _mapper.Map<WishRequest>(wish);

            return Ok(request);
        }

        [HttpGet]
        [Route("wishes")]
        public IActionResult GetAllWishes()
        {
            var wishes = _service.GetAll<Wish>();

            var wishRequests = _mapper.Map<List<WishRequest>>(wishes);

            return Ok(wishRequests);
        }
    }
}
