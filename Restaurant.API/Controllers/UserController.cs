using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web.Resource;
using Restaurant.DataAccess.Entities;
using Restaurant.Domain.Services;

namespace Restaurant.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserService _userService;

        public UserController(
            ILogger<UserController> logger, 
            GraphServiceClient graphServiceClient,
            UserService userService)
            : base(logger, graphServiceClient)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var user = await GetLoggedUser();
            DbUser dbUser = await _userService.GetOrCreateUser(
                Guid.Parse(user.Id), user.DisplayName, user.UserPrincipalName);

            return Ok(dbUser);
        }
    }
}
