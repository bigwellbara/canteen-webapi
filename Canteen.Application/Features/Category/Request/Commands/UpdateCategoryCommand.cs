using Canteen.Application.DTOs.CategoryDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Category.Request.Commands
{
    internal class UpdateCategoryCommand : IRequest<GeneralResponse>
    {
        public int CategoryId { get; set; }
        public UpdateCategoryDto? categoryDto { get; set; }
    }
}