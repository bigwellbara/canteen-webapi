using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.MenuItemValidators;
using Canteen.Domain.Validators.OrderValidators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Domain.Aggregates.OrderAggregate
{
    public class OrderItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid OrderItemId { get; private set; } = Guid.NewGuid();
        public string MenuItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    


     public static OrderItem CreateOrderItem(string menuItemId,string name, decimal price, int quantity)
        {
            var oderItemValidator = new OrderItemValidator();

            var orderItemObjectToValidate = new OrderItem
            {
              MenuItemId=menuItemId,
                Name = name,
                Price = price,
                Quantity = quantity
              
            };

            var validationResult = oderItemValidator.Validate(orderItemObjectToValidate);

            if (validationResult.IsValid)
            {
                return orderItemObjectToValidate;
            }

            var orderItemException = new OrderItemNotValidException("The order item is not valid.");

            foreach (var itemError in validationResult.Errors)
            {
                orderItemException.validationErrors.Add(itemError.ErrorMessage);
            }

            throw orderItemException;
        }
    }

    }
