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
    }
}
