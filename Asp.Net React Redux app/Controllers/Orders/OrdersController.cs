using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_React_Redux_app.Data;
using Asp.Net_React_Redux_app.Data.Repositories.OrderRepo;
using Asp.Net_React_Redux_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Asp.Net_React_Redux_app.Controllers.Orders {
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase {
        private readonly IOrderRepo _orderRepo;
        private readonly ILogger<OrdersController> _logger;
        private readonly DataContext _dataContext;

        public OrdersController(
            IOrderRepo orderRepo,
            ILogger<OrdersController> logger,
            DataContext dataContext
        ) {
            dataContext.Orders.Add(new Order {
                Id = 0,
                User = dataContext.Users.First()
            });

            _orderRepo = orderRepo;
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders() {
            _logger.LogInformation("GetAllOrders was called");

            var orders = await _orderRepo.GetAllAsync();

            return Ok(orders);
        }
    }
}