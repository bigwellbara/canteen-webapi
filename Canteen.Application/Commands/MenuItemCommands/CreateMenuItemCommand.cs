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
    public class CreateMenuItemCommand : IRequest<OperationResult<MenuItem>>
    {

        public string UserProfileID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
