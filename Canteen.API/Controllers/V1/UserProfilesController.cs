using AutoMapper;
using Canteen.API.Contracts.UserProfiles.Requests;
using Canteen.API.Contracts.UserProfiles.Responses;
using Canteen.API.Filters;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.Queries.UserProfileQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]

    public class UserProfilesController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            //throw new NotImplementedException("Method Not implemented");
            var allUserProfilesQuery = new GetAllUserProfiles();
            var allUserProfileResponse = await _mediator.Send(allUserProfilesQuery);
            var allProfiles = _mapper.Map<List<UserProfileResponse>>(allUserProfileResponse.Payload);
            return Ok(allProfiles);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate userProfileCreated)
        {

         
            var createUserCommand = _mapper.Map<CreateUserCommand>(userProfileCreated);
            var createUserResponse = await _mediator.Send(createUserCommand);

            var userProfileResponse = _mapper.Map<UserProfileResponse>(createUserResponse.Payload);

            if (createUserResponse.IsError)
            {
                return HandleErrorResponse(createUserResponse.Errors);
            }
            else
            {
                return CreatedAtAction(nameof(GetUserProfileById), new { id = userProfileResponse.UserProfileId }, userProfileResponse);
            }


        }


        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var userProfileQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var userProfileResponse = await _mediator.Send(userProfileQuery);
            if (userProfileResponse.IsError)
            {
                return HandleErrorResponse(userProfileResponse.Errors);
            }
            else
            {
                var userProfile = _mapper.Map<UserProfileResponse>(userProfileResponse.Payload);
                return Ok(userProfile);
            }
        }


        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateModel]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate userProfileUpdated)
        {
            var updateUserProfileCommand = _mapper.Map<UpdateUserProfileBasicInformationCommand>(userProfileUpdated);
            updateUserProfileCommand.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(updateUserProfileCommand);

            if (response.IsError)
            {
                return HandleErrorResponse(response.Errors);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var deleteUserProfileCommand = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var deleteUserProfileResponse = await _mediator.Send(deleteUserProfileCommand);
            //await _mediator.Send(deleteUserProfileCommand);
            if (deleteUserProfileResponse.IsError)
            {
                return HandleErrorResponse(deleteUserProfileResponse.Errors);
            }
            else
            {
                return NoContent();
            }

        }
    }
}
