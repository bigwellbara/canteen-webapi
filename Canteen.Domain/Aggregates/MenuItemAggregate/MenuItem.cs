using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.MenuItemValidators;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Canteen.Domain.Aggregates.MenuItemAggregate
{
    public class MenuItem
    {
        private MenuItem()
        {

        }

        // This will map to the _id field in MongoDB
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid MenuItemId { get; private set; } = Guid.NewGuid();
        public string UserProfileID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Creates a menu item
        /// </summary>
        /// <param name="userProfileId">The id of user who created the menu item</param>
        /// <param name="name">Name of the menu item</param>
        /// <param name="description">Description of the menu item</param>
        /// <param name="price">Price of the menu item</param>
        /// <param name="category">The category where the menu item belongs to</param>
        /// <returns> < see cref="MenuItem"/>Returns if valid</returns>
        /// <exception cref="MenuItemNotValidException">Thrown if not valid</exception>
        public static MenuItem CreateMenuItem(string userProfileId, string name, string description, decimal price, string category, string imageUrl)
        {
            var menuItemValidator = new MenuItemValidator();

            var menuItemObjectToValidate = new MenuItem
            {
               UserProfileID=userProfileId,
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                ImageUrl = imageUrl
            };

            var validationResult = menuItemValidator.Validate(menuItemObjectToValidate);

            if (validationResult.IsValid)
            {
                return menuItemObjectToValidate;
            }

            var menuItemException = new MenuItemNotValidException("The menu item is not valid.");

            foreach (var itemError in validationResult.Errors)
            {
                menuItemException.validationErrors.Add(itemError.ErrorMessage);
            }

            throw menuItemException;
        }

        public void UpdateMenuItemName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var exception = new MenuItemNotValidException("Cannot update name." + "The provided name is not valid or is null");
                exception.validationErrors.Add("The provided name contains only white space or is null");
                throw exception;
            }

            Name = name;
            LastModified = DateTime.UtcNow;
        }

        public void UpdateMenuItemDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                var exception = new MenuItemNotValidException("Cannot update description." + "The provided description is not valid or is null");
                exception.validationErrors.Add("The provided description contains only white space or is null");
                throw exception;
            }

            Description = description;
            LastModified = DateTime.UtcNow;
        }

        public void UpdateMenuItemPrice(decimal price)
        {
            if (price <= 0)
            {
                var exception = new MenuItemNotValidException("Cannot update price." + "The provided price is not valid");
                exception.validationErrors.Add("The provided price is less or equal to zero.");
                throw exception;
            }

            Price = price;
            LastModified = DateTime.UtcNow;
        }
    }
}
