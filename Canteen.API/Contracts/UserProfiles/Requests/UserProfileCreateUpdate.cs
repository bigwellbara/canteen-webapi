using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UserProfileCreateUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^\+26377\d{7}$", ErrorMessage = "The phone number must be in the format +26377 followed by 7 digits.")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MinLength(3)]
        public string CurrentCity { get; set; }
    }
}
