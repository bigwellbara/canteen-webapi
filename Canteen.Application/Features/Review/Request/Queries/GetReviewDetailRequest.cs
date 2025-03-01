using Canteen.Application.DTOs.ReviewDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Review.Request.Queries
{
    public class GetReviewDetailRequest : IRequest<GetReviewDto>
    {
        public int ReviewId { get; set; }
    }
}