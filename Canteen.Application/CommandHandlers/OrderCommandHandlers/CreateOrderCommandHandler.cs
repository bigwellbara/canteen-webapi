using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate;
using Canteen.Domain.Exceptions;
using MediatR;

namespace Canteen.Application.CommandHandlers.OrderCommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OperationResult<Order>>
    {

        public readonly IMongoGenericRepository<Order> _orderRepository;

        public CreateOrderCommandHandler(IMongoGenericRepository<Order> orderRespository)
        {
            _orderRepository = orderRespository;   
        }
        public async Task<OperationResult<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var operationResult= new OperationResult<Order>();
            try
            {
                var order = Order.CreateOrder(
                    Guid.NewGuid(),
                    request.Items
                );
                await _orderRepository.InsertOneAsync(order,cancellationToken);
                operationResult.Payload = order;

                return operationResult;
            }
            catch (OrderNotValidException exception)
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
