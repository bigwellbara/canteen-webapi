using Canteen.Application.DTOs.MenuItemDTO;

namespace Canteen.Application.DTOs.CategoryDTO
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<GetMenuItemDto>? MenuItems { get; set; }
    }
}