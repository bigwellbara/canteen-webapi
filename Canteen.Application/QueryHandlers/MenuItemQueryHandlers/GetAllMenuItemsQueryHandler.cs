using System;
using System.Collections.Generic;
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
    public class GetAllMenuItemsQueryHandler : IRequestHandler<GetAllMenuItems, OperationResult<List<MenuItem>>>
    {
        private readonly MongoDbContext _mongoDbContext;

        public GetAllMenuItemsQueryHandler(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<OperationResult<List<MenuItem>>> Handle(GetAllMenuItems request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<MenuItem>>();

            try
            {
                var menuItems = await _mongoDbContext.MenuItems
                    .Find(_ => true)
                    .ToListAsync(cancellationToken);

                result.Payload = menuItems;
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
