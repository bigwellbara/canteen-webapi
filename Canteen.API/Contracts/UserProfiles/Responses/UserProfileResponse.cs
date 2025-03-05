using Canteen.Domain.Aggregates.UserProfileAggregate;

namespace Canteen.API.Contracts.UserProfiles.Responses
{
    public record UserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public BasicInfor BasicInfor { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
