using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Canteen.Application.Queries.OrderItermQueries
{
    public  class GetOrderItemById : IRequest<OperationResult<OrderItem>>
    {
        public Guid OrderItemId { get; set; }
    }
}
