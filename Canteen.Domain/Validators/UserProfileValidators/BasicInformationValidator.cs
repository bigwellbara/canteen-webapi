using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using FluentValidation;

namespace Canteen.Domain.Validators.UserProfileValidators
{
    public class BasicInformationValidator : AbstractValidator<BasicInfor>
    {
        public BasicInformationValidator()
        {
            RuleFor(infor => infor.FirstName)
             .NotNull().WithMessage("First name is required.")
             .MinimumLength(3).WithMessage("First name must be at least 3 characters long.")
             .MaximumLength(50).WithMessage("First name can contain at most 50 characters.")
             .Matches(@"^[^\d].*").WithMessage("First name cannot start with a number.");  // Rule added

            RuleFor(infor => infor.LastName)
                .NotNull().WithMessage("Last name is required.")
                .MinimumLength(3).WithMessage("Last name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Last name can contain at most 50 characters.")
                .Matches(@"^[^\d].*").WithMessage("Last name cannot start with a number.");  // Rule added


            RuleFor(infor => infor.EmailAddress)
                .NotNull().WithMessage("Email Address is required")
                .EmailAddress().WithMessage("The provided text is not in a valid email address format.");

            RuleFor(infor => infor.DateOfBirth)
                .NotNull().WithMessage("Date of birth is required")
                .InclusiveBetween(new DateTime
                                (DateTime.Now.AddYears(-120).Ticks),
                                new DateTime(DateTime.Now.AddYears(-18).Ticks))
                                .WithMessage("The age should be 18 years and above and upto 120 years old.");
        }

    }
}
