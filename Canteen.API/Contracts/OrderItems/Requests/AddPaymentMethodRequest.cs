using Canteen.Domain.Aggregates.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.OrderItems.Requests
{
    public record AddPaymentMethodRequest
    {
        [Required]
        public PaymentType Type { get; set; }
        [Required, StringLength(255, MinimumLength = 8)] 
        public string Details { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
