using Canteen.Application.DTOs.MenuItemDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class AddImageVideoMenuItemCommand : IRequest<GeneralResponse>
    {
        public int MenuItemId { get; set; }
        public AddImageVideoMenuItemDto ImageVideoMenuItemDto { get; set; }
    }
}