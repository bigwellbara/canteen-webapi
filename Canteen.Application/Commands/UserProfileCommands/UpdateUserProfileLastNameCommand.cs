using MediatR;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using Canteen.Application.OperationModels;

namespace Canteen.Application.Commands.UserProfileCommands
{
    public class UpdateUserProfileLastNameCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
        public string LastName { get; set; }
    }
}