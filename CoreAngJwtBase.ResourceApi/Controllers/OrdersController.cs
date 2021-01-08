using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using CoreAngJwtBase.ResourceApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngJwtBase.ResourceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BookStore store;
        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public OrdersController(BookStore store)
        {
            this.store = store;
        }
        [HttpGet]
        [Authorize (Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            if (!store.Order.ContainsKey(UserId))
            {
                return Ok(Enumerable.Empty<Book>());
            }

            var orderedBookIds = store.Order.Single(o => o.Key == UserId).Value;
            var orderedBooks = store.Books.Where(x => orderedBookIds.Contains(x.Id));

            return Ok(orderedBooks);
        }
    }
}
