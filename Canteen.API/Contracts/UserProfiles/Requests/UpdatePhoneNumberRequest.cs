using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UpdatePhoneNumberRequest
    {
        [RegularExpression(@"^\+26377\d{7}$", ErrorMessage = "The phone number must be in the format +26377 followed by 7 digits.")]
        public string Phone { get; set; }
    }
}
