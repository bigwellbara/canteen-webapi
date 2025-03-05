using AutoMapper;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Canteen.API.Mappings
{
    public class MenuItemMappings : Profile
    {
        public MenuItemMappings()
        {
            CreateMap<MenuItem, MenuItemResponse>();
        }
    }
}
