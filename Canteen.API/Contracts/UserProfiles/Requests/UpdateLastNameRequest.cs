using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UpdateLastNameRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
