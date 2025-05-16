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
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, OperationResult<Order>>
    {
        public readonly IMongoGenericRepository<Order> _orderRepository;

        public UpdateOrderStatusCommandHandler(IMongoGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult<Order>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<Order>();
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);
                if (order == null)
                {
                    operationResult.IsError = true;
                    operationResult.Errors.Add(new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"Order with ID {request.OrderId} not found"
                    });
                    return operationResult;
                }

                order.UpdateStatus(request.NewStatus);
                await _orderRepository.UpdateAsync(request.OrderId,order, cancellationToken);

                operationResult.Payload = order;
                return operationResult;
            }
            catch (OrderNotValidException exception)
            {
                operationResult.IsError = true;
                exception.validationErrors.ForEach(e =>
                {
                    operationResult.Errors.Add(new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = e
                    });
                });
                return operationResult;
            }
            catch (Exception ex)
            {
                operationResult.IsError = true;
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.ServerError,
                    Message = ex.Message
                });
                return operationResult;
            }
           
        }
    }
}
