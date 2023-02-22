using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Models.Product, Entities.ProductDto>()
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.Discount.HasValue ? (src.ProductPrice - ((src.ProductPrice * src.Discount) / 100)) : src.ProductPrice)
                    )
                .ForMember(
                    dest => dest.ProductCategoryName,
                    opt => opt.MapFrom(src => src.ProductCategory.ProductCategoryName.ToString().Trim())
                    );
            CreateMap<Entities.ProductForCreationDto, Models.Product>();
            CreateMap<Entities.ProductForUpdateDto, Models.Product>();
            CreateMap<Models.Product, Entities.ProductForUpdateDto>();
        }
    }
}
