namespace Canteen.API.Contracts.MenuItems.Responses
{
    public class MenuItemResponse
    {

        public Guid UserProfileID { get; set; }
        public Guid MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
