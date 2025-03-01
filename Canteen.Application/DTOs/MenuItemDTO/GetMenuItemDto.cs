namespace Canteen.Application.DTOs.MenuItemDTO
{
    public class GetMenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripion { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; } //foreign id
    }
}