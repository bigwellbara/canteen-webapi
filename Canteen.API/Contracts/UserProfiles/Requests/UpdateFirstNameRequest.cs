using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UpdateFirstNameRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }
    }
}
