using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using MediatR;

namespace Canteen.Application.CommandHandlers.MenuItemCommandHandlers
{
    public class UpdateMenuItemNameCommandHandler : BaseMenuItemCommandHandler,
     IRequestHandler<UpdateMenuItemNameCommand, OperationResult<MenuItem>>
    {
        public UpdateMenuItemNameCommandHandler(IMongoGenericRepository<MenuItem> menuItemRepository)
            : base(menuItemRepository) { }

        public async Task<OperationResult<MenuItem>> Handle(
            UpdateMenuItemNameCommand request,
            CancellationToken cancellationToken)
        {
            return await HandleCommonAsync(
                request.MenuItemId,
                async menuItem => menuItem.UpdateMenuItemName(request.Name),
                cancellationToken
            );
        }
    }
}
