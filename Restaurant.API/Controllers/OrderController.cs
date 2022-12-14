using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Restaurant.API.Model;
using Restaurant.Domain.Services;
using System.Net;

namespace Restaurant.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly OrderService _orderService;
        private readonly UserService _userService;

        public OrderController(
            ILogger<BaseController> logger, 
            GraphServiceClient graphServiceClient,
            OrderService orderService,
            UserService userService) 
            : base(logger, graphServiceClient)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet("table")]
        public async Task<IActionResult> GetTablesInfo()
        {
            var tableInfo = await _orderService.GetTablesInfo();

            return Ok(tableInfo);
        }

        [HttpGet("table/{tableNumber}/order")]
        public async Task<IActionResult> GetOrderForTable(int tableNumber)
        {
            var tableOrderDetails = await _orderService.GetTableOrderDetails(tableNumber);

            return Ok(tableOrderDetails);
        }

        [HttpPost("table/{tableNumber}/order")]
        public async Task<IActionResult> PlaceOrderToTable(int tableNumber, AddTableOrder order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await this.GetLoggedUser();
            var currentOrderOwner = await _orderService.GetOrderOwner(tableNumber);
            if (currentOrderOwner == null) 
            {
                currentOrderOwner = await _userService.GetOrCreateUser(Guid.Parse(user.Id), user.DisplayName, user.UserPrincipalName);
            } 
            else if (currentOrderOwner.Id != Guid.Parse(user.Id))
            {
                ModelState.AddModelError(string.Empty,
                    $"You are not allowed to modify this order, as you not the owner. Owner: {currentOrderOwner.Id}");
                return BadRequest(ModelState);
            }

            try
            {
                var tableItem = await _orderService.AddTableOrder(currentOrderOwner, tableNumber, order.ProductId, order.Quantity);
                return StatusCode((int)HttpStatusCode.Created, tableItem);
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("table/{tableNumber}/order/close")]
        public async Task<IActionResult> CloseOrder(int tableNumber)
        {
            var user = await this.GetLoggedUser();
            var currentOrderOwner = await _orderService.GetOrderOwner(tableNumber);
            if (currentOrderOwner == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user");
                return BadRequest(ModelState);
            }
            else if (currentOrderOwner.Id != Guid.Parse(user.Id))
            {
                ModelState.AddModelError(string.Empty,
                    $"You are not allowed to modify this order, as you not the owner. Owner: {currentOrderOwner.Id}");
                return BadRequest(ModelState);
            }

            try
            {
                await _orderService.CloseOrder(tableNumber);
            } 
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
