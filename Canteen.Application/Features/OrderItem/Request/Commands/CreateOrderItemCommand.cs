using Canteen.Application.DTOs.OrderItemDTO;
using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.OrderItem.Request.Commands
{
    public class CreateOrderItemCommand : IRequest<GeneralResponse>
    {
        public CreateOrderItemDto OrderItemDto { get; set; }
    }
}