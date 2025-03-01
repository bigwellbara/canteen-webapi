namespace Canteen.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } //Pending,Approved,In-Draft
        public DateTime OrderDate { get; set; }

        //Relaionships
        public int UserId { get; set; }

        public List<OrderItem>? orderItems { get; }
    }
}