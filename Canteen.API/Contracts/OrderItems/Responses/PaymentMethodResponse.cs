using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Contracts.OrderItems.Responses
{
    public class PaymentMethodResponse
    {
       public Guid PaymentMethodId { get; set; }
       public PaymentType Type { get; set; }
       public string MaskedDetails { get; set; }
   public  bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }
    }
}
