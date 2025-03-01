using Canteen.Application.DTOs.OrderDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Order.Request.Commands
{
    public class UpdateOrderCommand : IRequest<GeneralResponse>
    {
        public int OrderId { get; set; }
        public UpdateOrderDto OrderDto { get; set; }
    }
}