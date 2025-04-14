namespace Canteen.API.Contracts.OrderItems.Responses
{
    public class OrderItemResponse
    {
        public Guid OrderItemId { get; set; }
        public Guid MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
