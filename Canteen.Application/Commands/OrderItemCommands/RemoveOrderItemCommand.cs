using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Canteen.Application.Commands.OrderItemCommands
{
    public class RemoveOrderItemCommand :IRequest<OperationResult<OrderItem>>
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
    }
}
