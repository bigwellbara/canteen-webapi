using Canteen.Application.DTOs.ReviewDTO;
using MediatR;

namespace Canteen.Application.Features.Review.Request.Queries
{
    public class GetReviewListForUserRequest : IRequest<List<GetReviewDto>>
    {
        public int UserId { get; set; }
    }
}