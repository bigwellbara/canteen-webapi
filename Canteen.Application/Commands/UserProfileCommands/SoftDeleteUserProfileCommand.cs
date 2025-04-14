using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using MediatR;

namespace Canteen.Application.Commands.UserProfileCommands
{
    public class SoftDeleteUserProfileCommand : IRequest<OperationResult<bool>>
    {
        public Guid UserProfileId { get; set; }
        public string DeletedBy { get; set; } // Optional: track who deleted
    }
}
