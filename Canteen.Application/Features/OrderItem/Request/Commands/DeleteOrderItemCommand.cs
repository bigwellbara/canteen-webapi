using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.OrderItem.Request.Commands
{
    public class DeleteOrderItemCommand : IRequest<GeneralResponse>
    {
        public int OrderItemId { get; set; }
    }
}