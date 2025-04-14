using Canteen.Application.CommandHandlers.UserProfileCommandHandlers;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;

public class UpdateUserProfileFirstNameCommandHandler
    : BaseUserProfileCommandHandler, IRequestHandler<UpdateUserProfileFirstNameCommand, OperationResult<UserProfile>>
{
    public UpdateUserProfileFirstNameCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
        : base(userProfileRepository) { }

    public async Task<OperationResult<UserProfile>> Handle(
        UpdateUserProfileFirstNameCommand request,
        CancellationToken cancellationToken)
    {
        return await HandleCommonAsync(request.UserProfileId, async userProfile =>
        {
            if (userProfile.BasicInfor == null)
            {
                throw new InvalidOperationException("Basic information not initialized");
            }

            var updatedBasicInfo = BasicInfor.CreatePartialUpdate(
                existingInfo: userProfile.BasicInfor,
                firstName: request.FirstName
            );

            userProfile.UpdateBasicInfor(updatedBasicInfo);
        }, cancellationToken);
    }
}