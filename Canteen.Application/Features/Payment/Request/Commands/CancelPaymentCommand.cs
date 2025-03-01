using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Payment.Request.Commands
{
    public class CancelPaymentCommand : IRequest<GeneralResponse>
    {
        public int PaymentId { get; set; }
    }
}