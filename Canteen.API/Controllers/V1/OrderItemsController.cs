using AutoMapper;
using Canteen.API.Contracts.MenuItems.Requests;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.API.Contracts.OrderItems.Requests;
using Canteen.API.Contracts.OrderItems.Responses;
using Canteen.API.Filters;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Application.Commands.OrderItemCommands;
using Canteen.Application.Queries.MenuItemQueries;
using Canteen.Application.Queries.OrderItermQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] AddOrderItemRequest request)
        {

            var orderItemcommand = _mapper.Map<AddOrderItemCommand>(request);
            var createOrderItemResult = await _mediator.Send(orderItemcommand);
            var orderItemResponse = _mapper.Map<OrderItemResponse>(createOrderItemResult.Payload);

            if (createOrderItemResult.IsError)
            {
                return HandleErrorResponse(createOrderItemResult.Errors);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = orderItemResponse.OrderItemId }, orderItemResponse);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderItemsQuery = new GetAllOrderItems();
            var allOrderItemsResponse = await _mediator.Send(orderItemsQuery);
            var mappedOrderItems = _mapper.Map<List<OrderItemResponse>>(allOrderItemsResponse.Payload);

            if (allOrderItemsResponse.IsError)
            {
                return HandleErrorResponse(allOrderItemsResponse.Errors);

            }
            else
            {
                return Ok(mappedOrderItems);
            }


        }


        [HttpGet]
        [Route(ApiRoutes.OrderItems.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var oderItemId = Guid.Parse(id);
            var oderItemsQuery = new GetOrderItemById() { OrderItemId = oderItemId };
            var orderItemResponse = await _mediator.Send(oderItemsQuery);
            var mappedOrderItem = _mapper.Map<OrderItemResponse>(orderItemResponse.Payload);

            if (orderItemResponse.IsError)
            {
                return HandleErrorResponse(orderItemResponse.Errors);
            }
            else
            {

                return Ok(mappedOrderItem);
            }


        }
    }
}
