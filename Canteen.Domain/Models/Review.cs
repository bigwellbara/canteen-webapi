namespace Canteen.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }

        // Relationships
        public int UserId { get; set; }

        public int MenuItemId { get; set; }
    }
}