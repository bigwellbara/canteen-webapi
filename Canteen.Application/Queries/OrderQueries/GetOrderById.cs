using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate;
using MediatR;

namespace Canteen.Application.Queries.OrderQueries
{
    public class GetOrderById : IRequest<OperationResult<Order>>
    {
        public Guid OrderId { get; set; }
    }
}
