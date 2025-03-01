using Canteen.Application.DTOs.ReviewDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Review.Request.Commands
{
    public class UpdateReviewCommand : IRequest<GeneralResponse>
    {
        public int ReviewId { get; set; }
        public UpdateReviewDto reviewDto { get; set; }
    }
}