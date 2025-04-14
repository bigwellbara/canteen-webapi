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
    public class AddOrderItemCommand :IRequest<OperationResult<OrderItem>>
    {

        public string MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
