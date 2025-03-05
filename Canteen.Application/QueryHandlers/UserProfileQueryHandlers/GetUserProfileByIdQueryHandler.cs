using System;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.UserProfileQueries;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using MongoDB.Driver;

namespace Canteen.Application.QueryHandlers.UserProfileQueryHandlers
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetProfileById, OperationResult<UserProfile>>
    {
        private readonly MongoDbContext _mongoDbContext;

        public GetUserProfileByIdQueryHandler(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<OperationResult<UserProfile>> Handle(GetProfileById request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _mongoDbContext.UserProfiles
                    .Find(up => up.UserProfileId == request.UserProfileId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (userProfile is null)
                {
                    operationResult.IsError = true;
                    operationResult.Errors.Add(new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"The user profile with the ID of {request.UserProfileId} was not found!"
                    });

                    return operationResult;
                }

                operationResult.Payload = userProfile;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.ServerError,
                    Message = e.Message
                });
            }

            return operationResult;
        }
    }
}
