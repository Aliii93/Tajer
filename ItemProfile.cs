using AutoMapper;
using TajerTest.InputsOutPuts;
using TajerTest.Models;

namespace TajerTest
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemOutPut>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ItemDesc))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ItemDate));
            CreateMap<ItemInput, Item>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ItemDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ItemDesc, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id));
                
            
                
        }
    }
}
