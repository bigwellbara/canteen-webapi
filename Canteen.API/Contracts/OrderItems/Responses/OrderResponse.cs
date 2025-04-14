namespace Canteen.API.Contracts.OrderItems.Responses
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
