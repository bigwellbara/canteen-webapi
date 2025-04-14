using AutoMapper;
using Canteen.API.Contracts.MenuItems.Requests;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.API.Filters;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Application.Queries.MenuItemQueries;
using MediatR;

namespace Canteen.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]

   
    public class MenuItemsController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MenuItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemRequest createMenuItemRequest)
        {
            
            var menuItemCommand = _mapper.Map<CreateMenuItemCommand>(createMenuItemRequest);
            var createMenuItemResponse = await _mediator.Send(menuItemCommand);
            var menuItemResponse = _mapper.Map<MenuItemResponse>(createMenuItemResponse.Payload);
            if (createMenuItemResponse.IsError)
            {
                return HandleErrorResponse(createMenuItemResponse.Errors);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = menuItemResponse.MenuItemId }, menuItemResponse);
            }

        }

        //[HttpPost]
        //[ValidateModel]
        //public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemRequest request)
        //{

        //    var command = _mapper.Map<CreateMenuItemCommand>(request);
        //    var operationResult = await _mediator.Send(command);
        //    var response = _mapper.Map<MenuItemResponse>(operationResult.Payload); 
        //    if (operationResult.IsError)
        //    {
        //        return HandleErrorResponse(operationResult.Errors);
        //    }
        //    return CreatedAtAction(
        //        nameof(GetById),
        //        new { id = response.MenuItemId },
        //        response
        //    );
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItemsQuery = new GetAllMenuItems();
            var allMenuItemsResponse = await _mediator.Send(menuItemsQuery);
            var mappedMenuItems = _mapper.Map<List<MenuItemResponse>>(allMenuItemsResponse.Payload);

            if (allMenuItemsResponse.IsError)
            {
                return HandleErrorResponse(allMenuItemsResponse.Errors);

            }
            else
            {
                return Ok(mappedMenuItems);
            }


        }

        [HttpGet]
        [Route(ApiRoutes.MenuItems.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var menuItemId = Guid.Parse(id);
            var menuItemsQuery = new GetMenuItemById() { MenuItemId = menuItemId };
            var menuItemResponse = await _mediator.Send(menuItemsQuery);
            var mappedMenuItem = _mapper.Map<MenuItemResponse>(menuItemResponse.Payload);

            if (menuItemResponse.IsError)
            {
                return HandleErrorResponse(menuItemResponse.Errors);
            }
            else
            {

                return Ok(mappedMenuItem);
            }


        }



        [HttpPatch(ApiRoutes.MenuItems.NameRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateName(string id, [FromBody] UpdateNameRequest request)
        {
            var command = _mapper.Map<UpdateMenuItemNameCommand>(request);
            command.MenuItemId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);

            var getQuery = new GetMenuItemById { MenuItemId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getQuery);

            return getResult.IsError
                ? HandleErrorResponse(getResult.Errors)
                : Ok(_mapper.Map<MenuItemResponse>(getResult.Payload));
        }


        [HttpPatch(ApiRoutes.MenuItems.DescriptionRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdateDescription(string id, [FromBody] UpdateDescriptionRequest request)
        {
            var command = _mapper.Map<UpdateMenuItemDescriptionCommand>(request);
            command.MenuItemId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);

            var getQuery = new GetMenuItemById { MenuItemId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getQuery);

            return getResult.IsError
                ? HandleErrorResponse(getResult.Errors)
                : Ok(_mapper.Map<MenuItemResponse>(getResult.Payload));
        }

        [HttpPatch(ApiRoutes.MenuItems.PriceRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> UpdatePrice(string id, [FromBody] UpdatePriceRequest request)
        {
            var command = _mapper.Map<UpdateMenuItemPriceCommand>(request);
            command.MenuItemId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.IsError)
                return HandleErrorResponse(response.Errors);

            var getQuery = new GetMenuItemById { MenuItemId = Guid.Parse(id) };
            var getResult = await _mediator.Send(getQuery);

            return getResult.IsError
                ? HandleErrorResponse(getResult.Errors)
                : Ok(_mapper.Map<MenuItemResponse>(getResult.Payload));
        }

    }
}
