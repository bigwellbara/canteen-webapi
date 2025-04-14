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
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItems, OperationResult<List<OrderItem>>>
    {
        private readonly IMongoGenericRepository<OrderItem> _orderItemRepository;

        public GetAllOrderItemsQueryHandler(IMongoGenericRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OperationResult<List<OrderItem>>> Handle(GetAllOrderItems request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<OrderItem>>();

            try
            {
                // Use the repository to fetch all menu items
                var orderItems = await _orderItemRepository.GetAllAsync(cancellationToken);

                result.Payload = orderItems;
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
