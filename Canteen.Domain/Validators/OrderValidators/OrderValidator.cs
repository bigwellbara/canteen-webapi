using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate;
using FluentValidation;

namespace Canteen.Domain.Validators.OrderValidators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.UserProfileId)
                .NotEmpty().WithMessage("User profile ID is required.");

            RuleFor(order => order.Items)
                .NotNull().WithMessage("Order items cannot be null.")
                .NotEmpty().WithMessage("Order must contain at least one item.");

            RuleForEach(order => order.Items).ChildRules(orderItem =>
            {
                orderItem.RuleFor(i => i.MenuItemId)
                    .NotEmpty().WithMessage("Menu item ID is required.");

                orderItem.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

                orderItem.RuleFor(i => i.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than zero.");
            });

            RuleFor(order => order.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than zero.");
        }
    }
}
