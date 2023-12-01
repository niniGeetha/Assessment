using AutoMapper;
using eCommerceStore.Models.Domain;
using eCommerceStore.Models.DTO;

namespace eCommerceStore.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ItemDto, Item>().ReverseMap();
            CreateMap<CartItemDto,CartItem>().ReverseMap();
            CreateMap<AddItemRequestDto, Item>().ReverseMap();
            CreateMap<UpdateItemRequestDto, Item>().ReverseMap();           
            CreateMap<AddCartItemRequestDto, CartItem>().ReverseMap();
            CreateMap<UpdateCartItemRequestDto, CartItem>().ReverseMap();
            CreateMap<UpdateCartItemRequestDto, CartItemDto>().ReverseMap();

        }
    }
}
