using Canteen.Application.DTOs.CategoryDTO;
using Canteen.Application.Responses;
using MediatR;

namespace Canteen.Application.Features.Category.Request.Commands
{
    public class CreateCategoryCommand : IRequest<GeneralResponse>
    {
        public CreateCategoryDto categoryDto { get; set; }
    }
}