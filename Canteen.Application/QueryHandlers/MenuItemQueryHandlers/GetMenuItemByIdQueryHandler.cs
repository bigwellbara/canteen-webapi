using System;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.MenuItemQueries;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using MediatR;
using MongoDB.Driver;

namespace Canteen.Application.QueryHandlers.MenuItemQueryHandlers
{
    public class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemById, OperationResult<MenuItem>>
    {
        private readonly MongoDbContext _mongoDbContext;

        public GetMenuItemByIdQueryHandler(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<OperationResult<MenuItem>> Handle(GetMenuItemById request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<MenuItem>();

            try
            {
                var menuItem = await _mongoDbContext.MenuItems
                    .Find(menu_item => menu_item.MenuItemId == request.MenuItemId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (menuItem is null)
                {
                    var error = new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"The menu item with the ID of {request.MenuItemId} is not found!"
                    };
                    operationResult.IsError = true;
                    operationResult.Errors.Add(error);
                    return operationResult;
                }

                operationResult.Payload = menuItem;
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
