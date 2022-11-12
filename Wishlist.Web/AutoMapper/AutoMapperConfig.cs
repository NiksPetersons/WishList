using AutoMapper;
using WishList.Core.Models;
using Wishlist.Web.RequestModels;

namespace Wishlist.Web.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper MapperConfig()
    {
        var config = new MapperConfiguration(
            x =>
            {
                x.CreateMap<WishRequest, Wish>()
                    .ForMember(x => x.Id, options => options.Ignore());
                x.CreateMap<Wish, WishRequest>();
            }
    );

        return config.CreateMapper();
    }
}