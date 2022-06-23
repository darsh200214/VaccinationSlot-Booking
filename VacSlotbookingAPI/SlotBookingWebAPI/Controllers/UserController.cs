using Business.Interfaces;
using SlotBookingWebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utility;

namespace SlotBookingWebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SkipMyGlobalActionFilter]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }       

        [HttpGet(ApiRoutes.Users.GetUsersDetailsById)]
        public async Task<IActionResult> GetUsersDetailsById([FromRoute] int Id)
        {
            return Ok(await _userService.GetUsersDetailsById(Id));
        }       
        
    }
}