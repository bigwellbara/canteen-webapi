using Canteen.Application.DTOs.OrderItemDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.OrderItem.Request.Queries
{
    public class GetOrderItemRequest : IRequest<GetOrderItemDto>
    {
        public int OrderItemId { get; set; }
    }
}