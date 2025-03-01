namespace Canteen.Application.DTOs.PaymentDTO
{
    public class CreatePaymentDto(decimal _Amount, int _OrderId, int _UserId)
    {
        public decimal Amount { get; set; } = _Amount;
        public int OrderId { get; set; } = _OrderId;
        public int UserId { get; set; } = _UserId;
    }
}