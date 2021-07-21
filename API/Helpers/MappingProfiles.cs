using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
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

            CreateMap<Address, AddressDto>().ReverseMap(); /*tozihat safe 12 mored 4*/
        }
    }
}
