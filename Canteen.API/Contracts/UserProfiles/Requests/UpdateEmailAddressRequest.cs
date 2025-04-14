using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UpdateEmailAddressRequest
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
