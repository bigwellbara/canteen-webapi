namespace Canteen.Application.DTOs.MenuItemDTO
{
    public class CreateMenuItemDto(string _Name, string _Desciption)
    {
        public string Name { get; set; } = _Name;
        public string Descripion { get; set; } = _Desciption;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}