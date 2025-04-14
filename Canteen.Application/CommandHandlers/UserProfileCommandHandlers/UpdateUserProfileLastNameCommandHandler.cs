using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace Canteen.Application.CommandHandlers.UserProfileCommandHandlers
{
    public class UpdateUserProfileLastNameCommandHandler
      : BaseUserProfileCommandHandler, IRequestHandler<UpdateUserProfileLastNameCommand, OperationResult<UserProfile>>
    {
        public UpdateUserProfileLastNameCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
            : base(userProfileRepository) { }

        public async Task<OperationResult<UserProfile>> Handle(
            UpdateUserProfileLastNameCommand request,
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
                              lastName: request.LastName
                          );
                userProfile.UpdateBasicInfor(updatedBasicInfo);
            }, cancellationToken);
        }
    }
}
