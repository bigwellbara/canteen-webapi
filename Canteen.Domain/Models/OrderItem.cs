namespace Canteen.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Relationship
        public int OrderId { get; set; } //foreign Id

        public int MenuItemId { get; set; }
    }
}