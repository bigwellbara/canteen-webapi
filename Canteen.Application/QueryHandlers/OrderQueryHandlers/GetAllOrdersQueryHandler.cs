using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.OrderQueries;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate;
using MediatR;
namespace Canteen.Application.QueryHandlers.OrderQueryHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrders, OperationResult<List<Order>>>
    {
        private readonly IMongoGenericRepository<Order> _orderRepository;
        public GetAllOrdersQueryHandler(IMongoGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult<List<Order>>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
           var result = new OperationResult<List<Order>>();
            try
            {
                // Use the repository to fetch all menu items
                var orders = await _orderRepository.GetAllAsync(cancellationToken);
                result.Payload = orders;
            }
            catch (Exception e)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}",
                };
                result.Errors.Add(error);
            }
            return result;
        }
    }
}
