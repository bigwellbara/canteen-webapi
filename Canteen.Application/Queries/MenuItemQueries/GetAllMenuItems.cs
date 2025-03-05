using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Application.OperationModels;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using MediatR;

namespace Canteen.Application.Queries.MenuItemQueries
{
    public class GetAllMenuItems : IRequest<OperationResult<List<MenuItem>>>
    {
    }
}
