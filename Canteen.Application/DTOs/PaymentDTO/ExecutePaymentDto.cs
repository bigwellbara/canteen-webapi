namespace Canteen.Application.DTOs.PaymentDTO
{
    public class ExecutePaymentDto(string _PaymentMethod, string _Status)
    {
        public string PaymentMethod { get; set; } = _PaymentMethod;
        public string Status { get; set; } = _Status;
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}