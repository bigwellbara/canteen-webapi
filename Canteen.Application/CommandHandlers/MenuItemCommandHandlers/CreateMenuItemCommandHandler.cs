//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Canteen.Application.Commands.MenuItemCommands;
//using Canteen.Application.Enums;
//using Canteen.Application.OperationModels;
//using Canteen.DataAccessLayer.MongoRepositories;
//using Canteen.Domain.Aggregates.MenuItemAggregate;
//using Canteen.Domain.Exceptions;
//using MediatR;

//namespace Canteen.Application.CommandHandlers.MenuItemCommandHandlers
//{
//    public class CreateMenuItemCommandHandler :IRequestHandler<CreateMenuItemCommand, OperationResult<MenuItem>>
//    {
//        private readonly IMongoGenericRepository<MenuItem> _menuItemRepository;
//        public CreateMenuItemCommandHandler( IMongoGenericRepository<MenuItem> menuItemRepository)
//        {
//            _menuItemRepository = menuItemRepository;
//        }

//        public async Task<OperationResult<MenuItem>> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
//        {
//            var operationResult= new OperationResult<MenuItem>();

//            try
//            {
//                var menuItem = MenuItem.CreateMenuItem(

//                    request.UserProfileID,
//                    request.Name,
//                    request.Description,
//                    request.Price,
//                    request.Category

//                );

//                await _menuItemRepository.InsertOneAsync( menuItem, cancellationToken );
//                operationResult.Payload= menuItem;

//                return operationResult;

//            }
//            catch (MenuItemNotValidException exception)
//            {
//                operationResult.IsError = true;

//                exception.validationErrors.ForEach(e =>
//                {
//                    var error = new Error
//                    {
//                        Code = ErrorCode.ValidationError,
//                        Message = $"{exception.Message}",
//                    };
//                    operationResult.Errors.Add(error);
//                });

//                return operationResult;
//            }
//            catch (Exception e)
//            {
//                operationResult.IsError = true;
//                var error = new Error
//                {
//                    Code = ErrorCode.UnknownError,
//                    Message = $"{e.Message}",
//                };
//                operationResult.Errors.Add(error);

//                return operationResult;
//            }
//        }
//    }
//}


using System;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using Canteen.Domain.Exceptions;
using MediatR;
using Canteen.DataAccessLayer.MongoRepositories;

namespace Canteen.Application.CommandHandlers.MenuItemCommandHandlers
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, OperationResult<MenuItem>>
    {
        private readonly IMongoGenericRepository<MenuItem> _menuItemRepository;

        public CreateMenuItemCommandHandler(IMongoGenericRepository<MenuItem> menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<OperationResult<MenuItem>> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<MenuItem>();
            try
            {
                var menuItem = MenuItem.CreateMenuItem(
                    Guid.NewGuid().ToString(),
                    request.Name,
                    request.Description,
                    request.Price,
                    request.Category,
                    request.ImageUrl
                );

                await _menuItemRepository.InsertOneAsync(menuItem, cancellationToken);

                operationResult.Payload = menuItem;

                return operationResult;
            }
            catch (MenuItemNotValidException exception)
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