using AutoMapper;
using Canteen.API.Contracts.MenuItems.Requests;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.API.Contracts.Order.Requests;
using Canteen.API.Contracts.Order.Responses;
using Canteen.API.Contracts.OrderItems.Responses;
using Canteen.API.Filters;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Application.Queries.MenuItemQueries;
using Canteen.Application.Queries.OrderItermQueries;
using Canteen.Application.Queries.OrderQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] CreateOrderRequest orderRequest)
        {
            var orderCommand = _mapper.Map<CreateOrderCommand>(orderRequest);
            var createOrderResult= await _mediator.Send(orderCommand);
            var createOrderResponse = _mapper.Map<OrderResponse>(createOrderResult.Payload);

            if (createOrderResult.IsError)
            {
                return HandleErrorResponse(createOrderResult.Errors);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = createOrderResponse.OrderId }, createOrderResponse);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrdersQuery = new GetAllOrders();
            var allOrdersResponse = await _mediator.Send(allOrdersQuery);
            var mappedOrders = _mapper.Map<List<OrderResponse>>(allOrdersResponse.Payload);

            if (allOrdersResponse.IsError)
            {
                return HandleErrorResponse(allOrdersResponse.Errors);

            }
            else
            {
                return Ok(mappedOrders);
            }


        }


        [HttpGet]
        [Route(ApiRoutes.Orders.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var oderId = Guid.Parse(id);
            var oderQuery = new GetOrderById() { OrderId = oderId };

            var orderResponse = await _mediator.Send(oderQuery);
            var mappedOrder = _mapper.Map<OrderResponse>(orderResponse.Payload);

            if (orderResponse.IsError)
            {
                return HandleErrorResponse(orderResponse.Errors);
            }
            else
            {

                return Ok(mappedOrder);
            }


        }

        [HttpPatch(ApiRoutes.Orders.StatusRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateOrderStatus(string id, [FromBody] UpdateOrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderStatusCommand>(request);
            command.OrderId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);

            var getQuery = new GetOrderById { OrderId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getQuery);

            return getResult.IsError
                ? HandleErrorResponse(getResult.Errors)
                : Ok(_mapper.Map<UpdateOrderStatusResponse>(getResult.Payload));
        }
    }
}
