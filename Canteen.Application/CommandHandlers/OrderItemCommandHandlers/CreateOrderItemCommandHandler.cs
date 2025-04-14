using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.OrderAggregate;
using Canteen.Domain.Exceptions;
using MediatR;

namespace Canteen.Application.CommandHandlers.OrderItemCommandHandlers
{
    public class CreateOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, OperationResult<OrderItem>>
    {

        private readonly IMongoGenericRepository<OrderItem> _oderItemRepository;

        public CreateOrderItemCommandHandler(IMongoGenericRepository<OrderItem> orderItemRepository)
        {
            _oderItemRepository = orderItemRepository;   
        }
        public async Task<OperationResult<OrderItem>> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<OrderItem>();
            try
            {
                var oderItem = OrderItem.CreateOrderItem(
                    Guid.NewGuid().ToString(),
                    request.Name,
                    request.Price,
                    request.Quantity
           
                );

                await _oderItemRepository.InsertOneAsync(oderItem, cancellationToken);

                operationResult.Payload = oderItem;

                return operationResult;
            }
            catch (OrderItemNotValidException exception)
            {
                operationResult.IsError = true;

                exception.validationErrors.ForEach(e =>
                {
                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{exception.Message}",
                    };
                    operationResult.Errors.Add(error);
                });

                return operationResult;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}",
                };
                operationResult.Errors.Add(error);

                return operationResult;
            }
        }
    }
}
