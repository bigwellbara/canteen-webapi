using AutoMapper;
using Canteen.API.Contracts.UserProfiles.Requests;
using Canteen.API.Contracts.UserProfiles.Responses;
using Canteen.API.Filters;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.UserProfileQueries;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

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


        //[HttpPatch]
        //[Route(ApiRoutes.UserProfiles.IdRoute)]
        //[ValidateModel]
        //[ValidateGuid("id")]
        //public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate userProfileUpdated)
        //{
        //    var updateUserProfileCommand = _mapper.Map<UpdateUserProfileBasicInformationCommand>(userProfileUpdated);
        //    updateUserProfileCommand.UserProfileId = Guid.Parse(id);
        //    var response = await _mediator.Send(updateUserProfileCommand);

        //    if (response.IsError)
        //    {
        //        return HandleErrorResponse(response.Errors);
        //    }
        //    return NoContent();
        //}

        // [HttpPatch("{id}")]
        // [ValidateGuid("id")]
        //public async Task<IActionResult> UpdateUserProfile(
        //string id,
        //[FromBody] UserProfileCreateUpdate request,
        //[FromQuery] string updateField)
        //    {
        //        IRequest<OperationResult<UserProfile>> command = updateField.ToLower() switch
        //        {
        //            "firstname" => _mapper.Map<UpdateUserProfileFirstNameCommand>(request),
        //            "lastname" => _mapper.Map<UpdateUserProfileLastNameCommand>(request),
        //            "email" => _mapper.Map<UpdateUserProfileEmailCommand>(request),
        //            "phone" => _mapper.Map<UpdateUserProfilePhoneCommand>(request),
        //            "dateofbirth" => _mapper.Map<UpdateUserProfileDateOfBirthCommand>(request),
        //            "currentcity" => _mapper.Map<UpdateUserProfileCurrentCityCommand>(request),
        //            _ => throw new ArgumentException("Invalid update field specified")
        //        };

        //        // Set the ID on all command types
        //        ((dynamic)command).UserProfileId = Guid.Parse(id);

        //        var response = await _mediator.Send(command);
        //        if (response.IsError) return HandleErrorResponse(response.Errors);
        //        return NoContent();
        //    }


        [HttpPatch(ApiRoutes.UserProfiles.FirstNameRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateFirstName(string id, [FromBody] UpdateFirstNameRequest request)
        {
            var command = _mapper.Map<UpdateUserProfileFirstNameCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);
            if (response.IsError) return HandleErrorResponse(response.Errors);
            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }


        [HttpPatch(ApiRoutes.UserProfiles.LastNameRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateLastName(string id, [FromBody] UpdateLastNameRequest request)
        {
            var command = _mapper.Map<UpdateUserProfileLastNameCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError) return HandleErrorResponse(response.Errors);
            //return NoContent();

            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }


        [HttpPatch(ApiRoutes.UserProfiles.EmailRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateEmail(string id, [FromBody] UpdateEmailAddressRequest request)
        {
            var command = _mapper.Map<UpdateUserProfileEmailCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError) return HandleErrorResponse(response.Errors);
            //return NoContent();

            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }



        [HttpPatch(ApiRoutes.UserProfiles.PhoneRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdatePhone(string id, [FromBody] UpdatePhoneNumberRequest request)
        {
            var command = _mapper.Map<UpdateUserProfilePhoneCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError) return HandleErrorResponse(response.Errors);
            //return NoContent();

            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }



        [HttpPatch(ApiRoutes.UserProfiles.DateOfBirthRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateDateOfBirth(string id, [FromBody] UpdateDateOfBirthRequest request)
        {
            var command = _mapper.Map<UpdateUserProfileDateOfBirthCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError) return HandleErrorResponse(response.Errors);
            //return NoContent();

            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }


        [HttpPatch(ApiRoutes.UserProfiles.CurrentCityRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateCurrentCity(string id, [FromBody] UpdateCurrentCityRequest request)
        {
            var command = _mapper.Map<UpdateUserProfileCurrentCityCommand>(request);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError) return HandleErrorResponse(response.Errors);
            //return NoContent();

            var getUserQuery = new GetProfileById { UserProfileId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getUserQuery);
            if (getResult.IsError)
            {
                return HandleErrorResponse(getResult.Errors);
            }
            return Ok(_mapper.Map<UserProfileResponse>(getResult.Payload));
        }



        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var deleteUserProfileCommand = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id) };
            var deleteUserProfileResponse = await _mediator.Send(deleteUserProfileCommand);
         
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
