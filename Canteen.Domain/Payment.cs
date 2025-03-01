﻿namespace Canteen.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public DateTime PaymentDate { get; set; }

        //relationship
        public int OrderId { get; set; } //foreign key

        public int UserId { get; set; } //foreign key
    }
}