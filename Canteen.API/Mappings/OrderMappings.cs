using AutoMapper;
using Canteen.API.Contracts.Order.Requests;
using Canteen.API.Contracts.Order.Responses;
using Canteen.API.Contracts.OrderItems.Requests;
using Canteen.API.Contracts.OrderItems.Responses;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Domain.Aggregates.MenuItemAggregate.OrderAggregate;
using Canteen.Domain.Aggregates.OrderAggregate;

namespace Canteen.API.Mappings
{
    public class OrderMappings :Profile
    {
        public OrderMappings() 
        {

      

            CreateMap<Order, OrderResponse>();
            CreateMap<UpdateOrderRequest, UpdateOrderStatusCommand>();
            //CreateMap<OrderItem, OrderItemResponse>();

            CreateMap<OrderItem, OrderItemResponse>()
                    .ForMember(dest => dest.MenuItemId,
                    opt => opt.MapFrom(src => Guid.Parse(src.MenuItemId)));

            CreateMap<AddOrderItemRequest, OrderItem>()
                .ForMember(dest => dest.MenuItemId, opt => opt.MapFrom(src => src.MenuItemId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            // This is key: AutoMapper needs help to map List<AddOrderItemRequest> to List<OrderItem>
            CreateMap<CreateOrderRequest, CreateOrderCommand>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // << nested map!


        }
    }
}
