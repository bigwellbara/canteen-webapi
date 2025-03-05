namespace Canteen.Domain.Models
{
    public class MenuItemImagesVideos
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Format { get; set; }
        public long SizeInBytes { get; set; }

        //relationship
        public MenuItem? menuItem { get; set; }

        public int MenuItemId { get; set; }
    }
}