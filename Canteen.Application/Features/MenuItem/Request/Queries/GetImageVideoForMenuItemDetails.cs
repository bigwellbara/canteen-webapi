using Canteen.Application.DTOs.MenuItemDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Queries
{
    public class GetImageVideoForMenuItemDetails : IRequest<List<GetMenuItemImagesVideos>>
    {
        public int MenuItemId { get; set; }
    }
}