using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ron.Blogs.Models;

namespace Ron.Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly HttpClient httpClient;
        public BlogController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            return APIReturn.NotFound;
        }

        [HttpPost("list")]
        public IActionResult List([FromBody]PageViewModel model)
        {
            return APIReturn.OK;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] BlogViewModel model)
        {

            return APIReturn.OK;
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] BlogViewModel model)
        {

            return APIReturn.OK;
        }
    }
}
