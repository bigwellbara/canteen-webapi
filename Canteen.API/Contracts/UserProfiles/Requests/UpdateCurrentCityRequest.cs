using System.ComponentModel.DataAnnotations;

namespace Canteen.API.Contracts.UserProfiles.Requests
{
    public record UpdateCurrentCityRequest
    {
        [Required]
        [MinLength(3)]
      
        public string CurrentCity { get; set; }
    }
}
