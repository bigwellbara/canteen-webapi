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
//    public class UpdateUserProfileBasicInformationCommandHandler : IRequestHandler<UpdateUserProfileBasicInformationCommand, OperationResult<UserProfile>>
//    {
//        private readonly MongoDbContext _mongoDbContext;

//        public UpdateUserProfileBasicInformationCommandHandler(MongoDbContext mongoDbContext)
//        {
//            _mongoDbContext = mongoDbContext;
//        }

//        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInformationCommand request, CancellationToken cancellationToken)
//        {
//            var operationResult = new OperationResult<UserProfile>();

//            try
//            {
//                var userProfile = await _mongoDbContext.UserProfiles
//                    .Find(u => u.UserProfileId == request.UserProfileId)
//                    .FirstOrDefaultAsync(cancellationToken);

//                if (userProfile is null)
//                {
//                    var error = new Error
//                    {
//                        Code = ErrorCode.NotFound,
//                        Message = $"The user profile with the ID of {request.UserProfileId} was not found!"
//                    };
//                    operationResult.IsError = true;
//                    operationResult.Errors.Add(error);
//                    return operationResult;
//                }

//                var basicInfor = BasicInfor.CreateBasicInfo(
//                    request.FirstName,
//                    request.LastName,
//                    request.EmailAddress,
//                    request.Phone,
//                    request.DateOfBirth,
//                    request.CurrentCity
//                );

//                userProfile.UpdateBasicInfor(basicInfor);

//                var updateDefinition = Builders<UserProfile>.Update
//                    .Set(u => u.BasicInfor, userProfile.BasicInfor);

//                var updateResult = await _mongoDbContext.UserProfiles
//                    .UpdateOneAsync(u => u.UserProfileId == request.UserProfileId, updateDefinition, cancellationToken: cancellationToken);

//                if (updateResult.MatchedCount == 0)
//                {
//                    var error = new Error
//                    {
//                        Code = ErrorCode.UnknownError,
//                        Message = "Failed to update the user profile."
//                    };
//                    operationResult.IsError = true;
//                    operationResult.Errors.Add(error);
//                    return operationResult;
//                }

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
//                    Code = ErrorCode.ServerError,
//                    Message = $"{e.Message}"
//                };
//                operationResult.Errors.Add(error);

//                return operationResult;
//            }
//        }
//    }
//}


//updated code

//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Canteen.Application.Commands.UserProfileCommands;
//using Canteen.Application.Enums;
//using Canteen.Application.OperationModels;
//using Canteen.Domain.Aggregates.UserProfileAggregate;
//using Canteen.Domain.Exceptions;
//using MediatR;
//using Canteen.DataAccessLayer.MongoRepositories;

//namespace Canteen.Application.CommandHandlers.UserProfileCommandHandlers
//{
//    public class UpdateUserProfileBasicInformationCommandHandler : IRequestHandler<UpdateUserProfileBasicInformationCommand, OperationResult<UserProfile>>
//    {
//        private readonly IMongoGenericRepository<UserProfile> _userProfileRepository;

//        public UpdateUserProfileBasicInformationCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
//        {
//            _userProfileRepository = userProfileRepository;
//        }

//        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInformationCommand request, CancellationToken cancellationToken)
//        {
//            var operationResult = new OperationResult<UserProfile>();

//            try
//            {
                
//                var userProfile = await _userProfileRepository.GetByIdAsync(request.UserProfileId, cancellationToken);

//                if (userProfile is null)

//                    if (userProfile is null)
//                {
//                    var error = new Error
//                    {
//                        Code = ErrorCode.NotFound,
//                        Message = $"The user profile with the ID of {request.UserProfileId} was not found!"
//                    };
//                    operationResult.IsError = true;
//                    operationResult.Errors.Add(error);
//                    return operationResult;
//                }

//                // Create the updated basic information
//                var basicInfor = BasicInfor.UpdateFirstName(
//                    request.FirstName
                    
//                );

                
//                userProfile.UpdateBasicInfor(basicInfor);

        
//                await _userProfileRepository.UpdateAsync(request.UserProfileId, userProfile, cancellationToken);

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
//                    Code = ErrorCode.ServerError,
//                    Message = $"{e.Message}"
//                };
//                operationResult.Errors.Add(error);

//                return operationResult;
//            }
//        }
//    }
//}

