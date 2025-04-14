using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Aggregates.OrderAggregate
{
    public enum PaymentType
    {
        CreditCard,
        DebitCard,
        Ecocash,
        Cash
    }
}
