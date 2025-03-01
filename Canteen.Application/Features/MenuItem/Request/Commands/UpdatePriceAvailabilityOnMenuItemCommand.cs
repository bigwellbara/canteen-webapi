using Canteen.Application.DTOs.MenuItemDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class UpdatePriceAvailabilityOnMenuItemCommand : IRequest<GeneralResponse>
    {
        public int MenuItemId { get; set; }
        public UpdatePriceAvailabilityOnMenuItemDto UpdatePriceAvailabilityOnMenuItemDto { get; set; }
    }
}