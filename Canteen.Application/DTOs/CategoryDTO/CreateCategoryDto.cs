namespace Canteen.Application.DTOs.CategoryDTO
{
    public class CreateCategoryDto(string _Name, string _Description)
    {
        public string Name { get; set; } = _Name;
        public string Description { get; set; } = _Description;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}