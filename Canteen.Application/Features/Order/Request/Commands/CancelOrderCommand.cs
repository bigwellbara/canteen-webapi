using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Order.Request.Commands
{
    public class CancelOrderCommand : IRequest<GeneralResponse>
    {
        public int OrderId { get; set; }
    }
}