using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.OrderAggregate;
using FluentValidation;

namespace Canteen.Domain.Validators.OrderValidators
{
    public class PaymentMethodValidator : AbstractValidator<PaymentMethod>
    {
        public PaymentMethodValidator()
        {
            RuleFor(x => x.UserProfileId)
                .NotEmpty().WithMessage("UserProfileId is required");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid payment type");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Payment details are required")
                .Length(8, 255).WithMessage("Details must be 8-255 characters");
        }
    }
}
