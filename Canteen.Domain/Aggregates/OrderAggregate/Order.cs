using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Aggregates.OrderAggregate;
using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.OrderValidators;
using MongoDB.Bson.Serialization.Attributes;
using OrderItem = Canteen.Domain.Aggregates.OrderAggregate.OrderItem;

namespace Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate
{
    public class Order
    {
        // Private constructor for immutability
        private Order() 
        {
        
        }

        [BsonId]
        public Guid OrderId { get; private set; }

        public Guid UserProfileId { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public decimal TotalPrice { get; private set; }

       
     

        // Factory method (matches your BasicInfor pattern)
        public static Order CreateOrder(
            Guid userProfileId,
            List<OrderItem> items,
            OrderStatus status = OrderStatus.Pending)
        {
            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                UserProfileId = userProfileId,
                Items = items,
                Status = status,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                TotalPrice = items.Sum(i => i.Price * i.Quantity)
            };

            ValidateOrder(order);
            return order;
        }

        // Validation method (identical to your BasicInfor pattern)
        private static void ValidateOrder(Order order)
        {
            var validator = new OrderValidator();
            var validationResult = validator.Validate(order);

            if (!validationResult.IsValid)
            {
                var exception = new OrderNotValidException("Order validation failed");
                foreach (var error in validationResult.Errors)
                {
                    exception.validationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }
        }

        // Update methods with validation
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            LastUpdated = DateTime.UtcNow;
            ValidateOrder(this); // Revalidate on update
        }
    }
}
