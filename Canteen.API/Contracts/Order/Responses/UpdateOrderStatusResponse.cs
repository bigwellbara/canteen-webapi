using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Contracts.Order.Responses
{
    public class UpdateOrderStatusResponse
    {
        public Guid OrderId { get; set; }
        public OrderStatus UpdatedStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
