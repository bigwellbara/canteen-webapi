namespace Canteen.Application.DTOs.OrderItemDTO
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
    }
}