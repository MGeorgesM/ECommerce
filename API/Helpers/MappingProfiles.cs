using API.Dtos;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(m => m.ProductBrand, mo => mo.MapFrom(s => s.ProductBrand.Name))
                .ForMember(m => m.ProductType, mo => mo.MapFrom(s => s.ProductType.Name))
                .ForMember(m => m.PictureUrl, mo => mo.MapFrom<ProductUrlResolver>());
            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, Address>();
            CreateMap<BasketDto, Basket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(m => m.DeliveryMethod, mo => mo.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(m => m.ShippingPrice, mo => mo.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(m => m.ProductId, mo => mo.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(m => m.ProductName, mo => mo.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(m => m.PictureUrl, mo => mo.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(m => m.PictureUrl, mo => mo.MapFrom<OrderItemUrlResolver>());
        }
    }
}