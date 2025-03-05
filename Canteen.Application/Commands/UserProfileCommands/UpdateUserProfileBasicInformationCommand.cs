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
    //we don't want to return anything after updating so it will be just a simple IRequest
    public class UpdateUserProfileBasicInformationCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; } //we are receiving this from the client don't get confused
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CurrentCity { get; set; }
    }
}
