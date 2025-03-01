using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Review.Request.Commands
{
    public class DeleteReviewCommand : IRequest<GeneralResponse>
    {
        public int ReviewId { get; set; }
    }
}