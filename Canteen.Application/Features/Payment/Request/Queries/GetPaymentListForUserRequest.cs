using Canteen.Application.DTOs.PaymentDTO;
using MediatR;

namespace Canteen.Application.Features.Payment.Request.Queries
{
    public class GetPaymentListForUserRequest : IRequest<GetPaymentDto>
    {
        public int UserId { get; set; }
    }
}