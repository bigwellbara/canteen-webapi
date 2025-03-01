using Canteen.Application.DTOs.OrderItemDTO;
using MediatR;

namespace Canteen.Application.Features.OrderItem.Request.Queries
{
    public class GetOrderItemListRequest : IRequest<List<GetOrderItemDto>>
    {
    }
}