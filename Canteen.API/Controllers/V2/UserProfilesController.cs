using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public IActionResult get_by_id(int id)
        {

            return Ok();
        }
    }
}
