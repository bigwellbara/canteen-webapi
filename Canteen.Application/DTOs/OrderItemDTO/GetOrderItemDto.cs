namespace Canteen.Application.DTOs.OrderItemDTO
{
    public class GetOrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}