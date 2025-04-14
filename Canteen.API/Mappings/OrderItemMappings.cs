using AutoMapper;
using Canteen.API.Contracts.OrderItems.Requests;
using Canteen.API.Contracts.OrderItems.Responses;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Mappings
{
    public class OrderItemMappings : Profile
    {

        public OrderItemMappings()
        {
            CreateMap<AddOrderItemRequest,AddOrderItemCommand>();
            CreateMap<OrderItem, OrderItemResponse>();
        }
    }
}
