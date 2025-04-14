using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using MediatR;

namespace Canteen.Application.Commands.MenuItemCommands
{
    public class UpdateMenuItemNameCommand:IRequest<OperationResult<MenuItem>>
    {
        public Guid MenuItemId { get; set; }
        public string Name { get; set; }
    }
}
