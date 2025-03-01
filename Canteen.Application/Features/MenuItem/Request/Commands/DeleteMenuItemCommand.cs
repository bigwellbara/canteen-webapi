using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class DeleteMenuItemCommand : IRequest<GeneralResponse>
    {
        public int MenuItemId { get; set; }
    }
}