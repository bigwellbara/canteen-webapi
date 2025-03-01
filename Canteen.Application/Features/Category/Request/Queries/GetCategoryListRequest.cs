using Canteen.Application.DTOs.CategoryDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.Category.Request.Queries
{
    public class GetCategoryListRequest : IRequest<List<GetCategoryDto>>
    {
    }
}