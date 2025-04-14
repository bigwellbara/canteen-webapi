using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.MenuItems.Requests
{
    public record UpdateNameRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
    }
}
