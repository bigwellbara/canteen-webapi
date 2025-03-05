using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace Canteen.Application.Queries.UserProfileQueries
{
    public class GetProfileById : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
