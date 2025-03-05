using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace Canteen.Application.Commands.UserProfileCommands
{
    public class DeleteUserProfileCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
