using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.OrderAggregate;
using FluentValidation;

namespace Canteen.Domain.Validators.OrderValidators
{
    public class OrderItemValidator :AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(item => item.Name)
                .NotNull().WithMessage("Name cannot be now.")
                .MinimumLength(3).WithMessage("The name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("The name can contain at most 50 characters long.");


            RuleFor(item => item.Price)
                .NotNull().WithMessage("Price cannot be null.");

            RuleFor(item => item.Quantity)
                .NotNull().WithMessage("Quantity cannot be null.");
               
        }
    }
}
