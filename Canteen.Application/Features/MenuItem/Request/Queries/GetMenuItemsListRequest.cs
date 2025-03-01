using Canteen.Application.DTOs.MenuItemDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Queries
{
    public class GetMenuItemsListRequest : IRequest<List<GetMenuItemDto>>
    {
    }
}