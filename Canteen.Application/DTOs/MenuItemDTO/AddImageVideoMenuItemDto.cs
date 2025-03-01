namespace Canteen.Application.DTOs.MenuItemDTO
{
    public class AddImageVideoMenuItemDto
    {
        public string FilePath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Format { get; set; }
        public long SizeInBytes { get; set; }
        public int MenuItemId { get; set; }
    }
}