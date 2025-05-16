using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.OrderItems.Requests
{
    public record AddOrderItemRequest
    {
        [Required(ErrorMessage = "MenuItemId is required")]
        public Guid MenuItemId { get; init; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be 1-100")]
        public int Quantity { get; init; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
    }
}
