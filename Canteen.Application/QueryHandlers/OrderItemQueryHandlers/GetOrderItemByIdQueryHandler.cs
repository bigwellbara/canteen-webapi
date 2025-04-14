using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.MenuItemQueries;
using Canteen.Application.Queries.OrderItermQueries;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Canteen.Application.QueryHandlers.OrderItemQueryHandlers
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemById, OperationResult<OrderItem>>
    {
        private readonly IMongoGenericRepository<OrderItem> _orderItemRepository;
        public GetOrderItemByIdQueryHandler(IMongoGenericRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OperationResult<OrderItem>> Handle(GetOrderItemById request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<OrderItem>();

            try
            {
                // Use the repository to fetch the menu item by ID
                var orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId, cancellationToken);

                if (orderItem is null)
                {
                    var error = new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"The menu item with the ID of {request.OrderItemId} is not found!"
                    };
                    operationResult.IsError = true;
                    operationResult.Errors.Add(error);
                    return operationResult;
                }

                operationResult.Payload = orderItem;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                operationResult.Errors.Add(error);
            }

            return operationResult;
        }
    }
}
