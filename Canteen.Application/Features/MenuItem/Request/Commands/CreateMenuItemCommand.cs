using Canteen.Application.DTOs.MenuItemDTO;
using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class CreateMenuItemCommand : IRequest<GeneralResponse>
    {
        public CreateMenuItemDto MenuItemDto { get; set; }
    }
}