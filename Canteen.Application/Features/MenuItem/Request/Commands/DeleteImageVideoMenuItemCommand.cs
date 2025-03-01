using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class DeleteImageVideoMenuItemCommand : IRequest<GeneralResponse>
    {
        public int ImageVideoId { get; set; }
    }
}