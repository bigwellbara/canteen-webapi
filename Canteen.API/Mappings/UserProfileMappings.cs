//using AutoMapper;
//using Canteen.API.Contracts.UserProfiles.Requests;
//using Canteen.API.Contracts.UserProfiles.Responses;
//using Canteen.Application.Commands.UserProfileCommands;
//using Canteen.Domain.Aggregates.UserProfileAggregate;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Canteen.API.Mappings
//{
//    public class UserProfileMappings : Profile
//    {
//        public UserProfileMappings()
//        {
//            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
//            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInformationCommand>();
//            CreateMap<UserProfile, UserProfileResponse>();
//            CreateMap<BasicInfor, BasicInformation>();
//        }
//    }
//}

using AutoMapper;
using Canteen.API.Contracts.UserProfiles.Requests;
using Canteen.API.Contracts.UserProfiles.Responses;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Domain.Aggregates.UserProfileAggregate;

namespace Canteen.API.Mappings
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            // Create command mapping
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            // Individual update command mappings
            CreateMap<UpdateFirstNameRequest, UpdateUserProfileFirstNameCommand>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName));
            CreateMap<UpdateLastNameRequest, UpdateUserProfileLastNameCommand>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
            CreateMap<UpdateEmailAddressRequest, UpdateUserProfileEmailCommand>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress));
            CreateMap<UpdatePhoneNumberRequest, UpdateUserProfilePhoneCommand>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            CreateMap<UpdateDateOfBirthRequest, UpdateUserProfileDateOfBirthCommand>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
            CreateMap<UpdateCurrentCityRequest, UpdateUserProfileCurrentCityCommand>()
                .ForMember(dest => dest.CurrentCity, opt => opt.MapFrom(src => src.CurrentCity));
            // Response mappings
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfor, BasicInformation>();
            // Reverse mapping for BasicInformation to BasicInfor if needed
            CreateMap<BasicInformation, BasicInfor>();
        }
    }
}
