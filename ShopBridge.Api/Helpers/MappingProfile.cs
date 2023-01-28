using AutoMapper;
using ShopBridge.Api.ModelDTO;
using ShopBridge.Core.Entities.Products;

namespace ShopBridge.Api.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<ProductModel, ProductModelDto>();
            CreateMap<ProductModelDto, ProductModel>();
        }
    }
}
