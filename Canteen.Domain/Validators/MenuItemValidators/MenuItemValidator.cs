using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using FluentValidation;

namespace Canteen.Domain.Validators.MenuItemValidators
{
    public class MenuItemValidator : AbstractValidator<MenuItem>
    {
        public MenuItemValidator()
        {
            RuleFor(item => item.Name)
                .NotNull().WithMessage("Name cannot be now.")
                .MinimumLength(3).WithMessage("The name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("The name can contain at most 50 characters long.");

            RuleFor(item => item.Description)
                .NotNull().WithMessage("Description cannot be null.")
                .MinimumLength(3).WithMessage("The description must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("The description can contain at most 50 characters long.");

            RuleFor(item => item.Price)
                .NotNull().WithMessage("Price cannot be null.");

            RuleFor(item => item.Category)
                .NotNull().WithMessage("Category cannot be null.")
                .MinimumLength(3).WithMessage("The category must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("The category can contain at most 50 characters long.");


        }

    }
}
