using Canteen.Application.DTOs.OrderDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Order.Request.Commands
{
    public class CreateOrderCommand : IRequest<GeneralResponse>
    {
        public CreateOrderDto orderDto { get; set; }
    }
}