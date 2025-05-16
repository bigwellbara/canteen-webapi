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
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderById, OperationResult<Order>>
    {
        private readonly IMongoGenericRepository<Order> _orderRepository;

        public GetOrderByIdQueryHandler(IMongoGenericRepository<Order> oderRepository)
        {
            _orderRepository = oderRepository;
        }

        public async Task<OperationResult<Order>> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Order>();
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);
                if (order is null)
                {
                    var newError= new Error
                    {
                        Code = Enums.ErrorCode.NotFound,
                        Message = $"Order with id {request.OrderId} not found",
                    };

                    result.IsError = true;
                    result.Errors.Add(newError);
                    return result;
                }
                result.Payload = order;

            }
            catch (Exception e)
            {

                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                result.Errors.Add(error);
            }
            return result;

        }
    }
}
