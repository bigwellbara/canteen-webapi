using Canteen.Application.DTOs.PaymentDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Payment.Request.Commands
{
    public class UpdatePaymentCommand : IRequest<GeneralResponse>
    {
        public int PaymentId { get; set; }
        public UpdatePaymentDto paymentDto { get; set; }
    }
}