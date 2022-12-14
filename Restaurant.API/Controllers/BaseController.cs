using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web.Resource;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly GraphServiceClient _graphServiceClient;
        protected readonly ILogger<BaseController> _logger;

        public BaseController(
            ILogger<BaseController> logger,
            GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }

        protected async Task<User> GetLoggedUser()
        {
            return await _graphServiceClient.Me.Request().GetAsync();
        }
    }
}
