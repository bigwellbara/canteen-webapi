using Canteen.API.Contracts.OrderItems.Responses;

namespace Canteen.API.Contracts.Order.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public Guid UserProfileId { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
