using AutoMapper;
using Canteen.API.Contracts.MenuItems.Requests;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Canteen.API.Mappings
{
    public class MenuItemMappings : Profile
    {
        public MenuItemMappings()
        {

            CreateMap<CreateMenuItemRequest, CreateMenuItemCommand>();
            CreateMap<MenuItem, MenuItemResponse>();


            CreateMap<UpdateNameRequest, UpdateMenuItemNameCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<UpdateDescriptionRequest, UpdateMenuItemDescriptionCommand>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<UpdatePriceRequest, UpdateMenuItemPriceCommand>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));



        }
    }
}
