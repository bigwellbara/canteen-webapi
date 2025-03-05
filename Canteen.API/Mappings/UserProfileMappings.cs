using AutoMapper;
using Canteen.API.Contracts.UserProfiles.Requests;
using Canteen.API.Contracts.UserProfiles.Responses;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Canteen.API.Mappings
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInformationCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfor, BasicInformation>();
        }
    }
}
