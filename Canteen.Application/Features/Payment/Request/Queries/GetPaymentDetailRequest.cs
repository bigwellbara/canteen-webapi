using Canteen.Application.DTOs.PaymentDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Payment.Request.Queries
{
    public class GetPaymentDetailRequest : IRequest<GetPaymentDto>
    {
        public int PaymentId { get; set; }
    }
}