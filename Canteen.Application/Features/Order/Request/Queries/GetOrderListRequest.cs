using Canteen.Application.DTOs.OrderDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Order.Request.Queries
{
    public class GetOrderListRequest : IRequest<List<GetOrderDto>>
    {
    }
}