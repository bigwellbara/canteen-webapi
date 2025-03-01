namespace Canteen.Application.DTOs.PaymentDTO
{
    public class GetPaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}