using System;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using Canteen.Domain.Exceptions;
using MediatR;
using MongoDB.Driver;

namespace Canteen.Application.CommandHandlers.UserProfileCommandHandlers
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly MongoDbContext _mongoDbContext;

        public DeleteUserProfileCommandHandler(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<UserProfile>();

            try
            {
                var userProfileToDelete = await _mongoDbContext.UserProfiles
                    .Find(u => u.UserProfileId == request.UserProfileId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (userProfileToDelete is null)
                {
                    var error = new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"The user profile with the ID of {request.UserProfileId} was not found!"
                    };
                    operationResult.IsError = true;
                    operationResult.Errors.Add(error);
                    return operationResult;
                }

                var deleteResult = await _mongoDbContext.UserProfiles
                    .DeleteOneAsync(u => u.UserProfileId == request.UserProfileId, cancellationToken);

                if (deleteResult.DeletedCount == 0)
                {
                    var error = new Error
                    {
                        Code = ErrorCode.UnknownError,
                        Message = "Failed to delete the user profile."
                    };
                    operationResult.IsError = true;
                    operationResult.Errors.Add(error);
                    return operationResult;
                }

                operationResult.Payload = userProfileToDelete;
                return operationResult;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                operationResult.Errors.Add(error);

                return operationResult;
            }
        }
    }
}
