using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAngJwtBase.ResourceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngJwtBase.ResourceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStore store;

        public BookController(BookStore store)
        {
            this.store = store;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAvailableBook()
        {
            return Ok(this.store.Books);
        }
    }
}
