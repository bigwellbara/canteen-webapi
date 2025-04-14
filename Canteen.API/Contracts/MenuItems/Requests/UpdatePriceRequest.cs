using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.MenuItems.Requests
{
    public record UpdatePriceRequest
    {
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
