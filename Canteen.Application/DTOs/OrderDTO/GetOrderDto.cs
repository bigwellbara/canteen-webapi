using Canteen.Application.DTOs.OrderItemDTO;

namespace Canteen.Application.DTOs.OrderDTO
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<GetOrderItemDto>? OrderItems { get; }
    }
}