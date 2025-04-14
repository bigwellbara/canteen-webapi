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
    public class UpdateUserProfilePhoneCommandHandler
     : BaseUserProfileCommandHandler, IRequestHandler<UpdateUserProfilePhoneCommand, OperationResult<UserProfile>>
    {
        public UpdateUserProfilePhoneCommandHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
            : base(userProfileRepository) { }

        public async Task<OperationResult<UserProfile>> Handle(
            UpdateUserProfilePhoneCommand request,
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
                              phone: request.Phone
                          );
                userProfile.UpdateBasicInfor(updatedBasicInfo);
            }, cancellationToken);
        }
    }

}
