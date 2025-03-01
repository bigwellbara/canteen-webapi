using Canteen.Application.DTOs.ReviewDTO;
using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Review.Request.Commands
{
    public class CreateReviewCommand : IRequest<GeneralResponse>
    {
        public CreateReviewDto reviewDto { get; set; }
    }
}