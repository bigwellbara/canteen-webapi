using Canteen.Application.DTOs.PaymentDTO;
using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Payment.Request.Commands
{
    public class ExecutePaymentCommand : IRequest<GeneralResponse>
    {
        public ExecutePaymentDto ExecutePaymentDto { get; set; }
    }
}