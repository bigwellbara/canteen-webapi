using AutoMapper;
using Canteen.Application.DTOs.CategoryDTO;
using Canteen.Application.DTOs.MenuItemDTO;
using Canteen.Application.DTOs.OrderDTO;
using Canteen.Application.DTOs.OrderItemDTO;
using Canteen.Application.DTOs.PaymentDTO;
using Canteen.Application.DTOs.ReviewDTO;
using Canteen.Domain;
using System.ComponentModel;

namespace Canteen.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, GetMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, AddImageMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
            CreateMap<MenuItemImagesVideos, AddImageMenuItemDto>().ReverseMap();
            CreateMap<MenuItemImagesVideos, GetMenuItemImagesVideos>().ReverseMap();
            CreateMap<MenuItem, UpdatePriceAvailabilityOnMenuItemDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
            CreateMap<Payment, CreatePaymentDto>().ReverseMap();
            CreateMap<Payment, ExecutePaymentDto>().ReverseMap();
            CreateMap<Payment, GetPaymentDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, GetReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
        }
    }
}