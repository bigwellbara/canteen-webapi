using System.ComponentModel.DataAnnotations;
using Canteen.API.Contracts.OrderItems.Requests;
using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Contracts.Order.Requests
{
    public record CreateOrderRequest
    {
        [Required(ErrorMessage = "UserProfileId is required")]
        public Guid UserProfileId { get; init; }

        [Required(ErrorMessage = "Items cannot be empty")]
        [MinLength(1, ErrorMessage = "At least one item is required")]
        public List<AddOrderItemRequest> Items { get; init; }

    }


}
