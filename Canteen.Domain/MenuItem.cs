using System.ComponentModel;

namespace Canteen.Domain
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripion { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        //Relationships
        public int CategoryId { get; set; } //foreign id

        public Category? category { get; set; }
    }
}