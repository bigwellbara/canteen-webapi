using Canteen.Application.DTOs.MenuItemDTO;
using MediatR;

namespace Canteen.Application.Features.MenuItem.Request.Queries
{
    public class GetMenuItemDetailRequest : IRequest<GetMenuItemDto>
    {
        public int MenuItemId { get; set; }
    }
}