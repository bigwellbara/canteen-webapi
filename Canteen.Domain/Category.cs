namespace Canteen.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        //Relationship
        public virtual List<MenuItem>? MenuItems { get; set; }
    }
}