using System.ComponentModel.DataAnnotations;
using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Contracts.Order.Requests
{
    public class UpdateOrderRequest
    {
        [Required(ErrorMessage = "Status is required")]
        public OrderStatus NewStatus { get; set; }
    }
}
