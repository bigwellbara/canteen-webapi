using Canteen.Application.DTOs.ReviewDTO;
using MediatR;

namespace Canteen.Application.Features.Review.Request.Queries
{
    public class GetReviewListForMenuItemRequest : IRequest<List<GetReviewDto>>
    {
        public int MenuItemId { get; set; }
    }
}