using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using Canteen.Domain.Exceptions;

public abstract class BaseUserProfileCommandHandler
{
    protected readonly IMongoGenericRepository<UserProfile> _userProfileRepository;

    protected BaseUserProfileCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    protected async Task<OperationResult<UserProfile>> HandleCommonAsync(
        Guid userProfileId,
        Func<UserProfile, Task> updateAction,
        CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<UserProfile>();

        try
        {
            var userProfile = await _userProfileRepository.GetByIdAsync(userProfileId, cancellationToken);

            if (userProfile is null)
            {
                operationResult.IsError = true;
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"User profile with ID {userProfileId} not found"
                });
                return operationResult;
            }

            await updateAction(userProfile);
            await _userProfileRepository.UpdateAsync(userProfileId, userProfile, cancellationToken);

            operationResult.Payload = userProfile;
            return operationResult;
        }
        catch (UserProfileNotValidException ex)
        {
            operationResult.IsError = true;
            ex.validationErrors.ForEach(e =>
            {
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.ValidationError,
                    Message = e
                });
            });
            return operationResult;
        }
        catch (Exception ex)
        {
            operationResult.IsError = true;
            operationResult.Errors.Add(new Error
            {
                Code = ErrorCode.ServerError,
                Message = ex.Message
            });
            return operationResult;
        }
    }
}


