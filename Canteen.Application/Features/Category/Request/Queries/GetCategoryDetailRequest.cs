using Canteen.Application.DTOs.CategoryDTO;
using MediatR;

namespace Canteen.Application.Features.Category.Request.Queries
{
    public class GetCategoryDetailRequest : IRequest<GetCategoryDto>
    {
        public int CategoryId { get; set; }
    }
}