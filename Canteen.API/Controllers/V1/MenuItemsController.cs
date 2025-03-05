using AutoMapper;
using Canteen.API.Contracts.MenuItems.Responses;
using Canteen.API.Filters;
using Canteen.Application.Queries.MenuItemQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
