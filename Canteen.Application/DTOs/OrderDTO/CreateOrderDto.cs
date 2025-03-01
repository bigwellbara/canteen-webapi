namespace Canteen.Application.DTOs.OrderDTO
{
    public class CreateOrderDto(int _UserId, decimal _TotalAmount)
    {
        public decimal TotalAmount { get; set; } = _TotalAmount;
        public string Status { get; set; } = "In-Draft";//Pending,Approved,In-Draft
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int UserId { get; set; } = _UserId;
    }
}