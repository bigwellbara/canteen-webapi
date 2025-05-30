﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.OrderAggregate;
using MediatR;

namespace Canteen.Application.Commands.OrderItemCommands
{
    public class AddPaymentMethodCommand :IRequest<OperationResult<PaymentMethod>>
    {
        public Guid UserProfileId { get; set; }
        public PaymentType Type { get; set; }
        public string Details { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
