//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Canteen.Application.Commands.UserProfileCommands;
//using Canteen.Application.Enums;
//using Canteen.Application.OperationModels;
//using Canteen.DataAccessLayer.Data;
//using Canteen.Domain.Aggregates.UserProfileAggregate;
//using Canteen.Domain.Exceptions;
//using MediatR;
//using MongoDB.Driver;

//namespace Canteen.Application.CommandHandlers.UserProfileCommandHandlers
//{
//    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
//    {
//        private readonly MongoDbContext _mongoDbContext;

//        public CreateUserCommandHandler(MongoDbContext mongoDbContext)
//        {
//            _mongoDbContext = mongoDbContext;
//        }

//        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
//        {
//            var operationResult = new OperationResult<UserProfile>();
//            try
//            {
//                var basicInfor = BasicInfor.CreateBasicInfo(
//                    request.FirstName,
//                    request.LastName,
//                    request.EmailAddress,
//                    request.Phone,
//                    request.DateOfBirth,
//                    request.CurrentCity
//                );

//                var userProfile = UserProfile.CreateUserProfile(
//                    Guid.NewGuid().ToString(),
//                    basicInfor
//                );

//                await _mongoDbContext.UserProfiles.InsertOneAsync(userProfile, cancellationToken: cancellationToken);

//                operationResult.Payload = userProfile;

//                return operationResult;
//            }
//            catch (UserProfileNotValidException exception)
//            {
//                operationResult.IsError = true;

//                exception.validationErrors.ForEach(e =>
//                {
//                    var error = new Error
//                    {
//                        Code = ErrorCode.ValidationError,
//                        Message = $"{exception.Message}",
//                    };
//                    operationResult.Errors.Add(error);
//                });

//                return operationResult;
//            }
//            catch (Exception e)
//            {
//                operationResult.IsError = true;
//                var error = new Error
//                {
//                    Code = ErrorCode.UnknownError,
//                    Message = $"{e.Message}",
//                };
//                operationResult.Errors.Add(error);

//                return operationResult;
//            }
//        }
//    }
//}


//updated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using Canteen.Domain.Exceptions;
using MediatR;
using Canteen.DataAccessLayer.MongoRepositories;

namespace Canteen.Application.CommandHandlers.UserProfileCommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly IMongoGenericRepository<UserProfile> _userProfileRepository;

        public CreateUserCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<UserProfile>();
            try
            {
                var basicInfor = BasicInfor.CreateBasicInfo(
                    request.FirstName,
                    request.LastName,
                    request.EmailAddress,
                    request.Phone,
                    request.DateOfBirth,
                    request.CurrentCity
                );

                var userProfile = UserProfile.CreateUserProfile(
                    Guid.NewGuid().ToString(),
                    basicInfor
                );

                
                await _userProfileRepository.InsertOneAsync(userProfile, cancellationToken);

                operationResult.Payload = userProfile;

                return operationResult;
            }
            catch (UserProfileNotValidException exception)
            {
                operationResult.IsError = true;

                exception.validationErrors.ForEach(e =>
                {
                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{exception.Message}",
                    };
                    operationResult.Errors.Add(error);
                });

                return operationResult;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}",
                };
                operationResult.Errors.Add(error);

                return operationResult;
            }
        }
    }
}
