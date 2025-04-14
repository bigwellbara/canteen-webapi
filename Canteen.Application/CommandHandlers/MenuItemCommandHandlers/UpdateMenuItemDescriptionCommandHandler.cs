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
    public class UpdateMenuItemDescriptionCommandHandler : BaseMenuItemCommandHandler,
     IRequestHandler<UpdateMenuItemDescriptionCommand, OperationResult<MenuItem>>
    {
        public UpdateMenuItemDescriptionCommandHandler(IMongoGenericRepository<MenuItem> menuItemRepository)
            : base(menuItemRepository) { }

        public async Task<OperationResult<MenuItem>> Handle(
            UpdateMenuItemDescriptionCommand request,
            CancellationToken cancellationToken)
        {
            return await HandleCommonAsync(
                request.MenuItemId,
                async menuItem => menuItem.UpdateMenuItemDescription(request.Description),
                cancellationToken
            );
        }
    }
}
