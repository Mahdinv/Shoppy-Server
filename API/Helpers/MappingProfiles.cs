using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            /*CreateMap<Product, ProductToReturnDto>();*/
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name)) /*tozihat safe 2 mored 4*/
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>()); /*tozihat safe 2 mored 5*/

            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap(); /*tozihat safe 12 mored 4*/

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>(); /*in address ba oon address bala fargh dare in male bakhshe ordere. bekhatere inke az address to OrderDto estefade shode*/

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price)); /*tozihat safe 17 mored 1*/

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl)) /*tozihat safe 17 mored 1*/
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>()); /*tozihat safe 18 mored 1*/
        }
    }
}
