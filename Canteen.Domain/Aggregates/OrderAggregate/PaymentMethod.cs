using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.OrderValidators;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Domain.Aggregates.OrderAggregate
{
    public class PaymentMethod
    {
        [BsonId]
        public Guid PaymentMethodId { get; private set; }

        public Guid UserProfileId { get; private set; }
        public PaymentType Type { get; private set; }
        public string Details { get; private set; } // Encrypted card number or mobile money details
        public bool IsDefault { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdated { get; private set; }

        // Private constructor for immutability
        private PaymentMethod() { }

        // Factory method with validation (matches your BasicInfor pattern)
        public static PaymentMethod Create(
            Guid userProfileId,
            PaymentType type,
            string details,
            bool isDefault = false)
        {
            var method = new PaymentMethod
            {
                PaymentMethodId = Guid.NewGuid(),
                UserProfileId = userProfileId,
                Type = type,
                Details = details,
                IsDefault = isDefault,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            ValidatePaymentMethod(method);
            return method;
        }

        private static void ValidatePaymentMethod(PaymentMethod method)
        {
            var validator = new PaymentMethodValidator();
            var validationResult = validator.Validate(method);

            if (!validationResult.IsValid)
            {
                var exception = new PaymentMethodNotValidException("Payment method validation failed");
                foreach (var error in validationResult.Errors)
                {
                    exception.validationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }
        }

        public void UpdateDetails(string newDetails)
        {
            Details = newDetails;
            LastUpdated = DateTime.UtcNow;
            ValidatePaymentMethod(this);
        }
    }
}
