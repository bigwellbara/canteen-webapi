using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.MenuItems.Requests
{
    public record UpdateDescriptionRequest
    {
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }
    }
}
