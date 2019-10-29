using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ron.Blogs.BLL;
using Ron.Blogs.Models;

namespace Ron.Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogsBLL blogsBLL;
        public BlogController(BlogsBLL blogsBLL)
        {
            this.blogsBLL = blogsBLL;
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var result = this.blogsBLL.List.FirstOrDefault(f => f.Id == id);
            if (result == null)
                return APIReturn.NotFound;

            return APIReturn.OK.SetData("detail", result);
        }

        [HttpPost("list")]
        public IActionResult List([FromBody]PageViewModel model)
        {
            var result = this.blogsBLL.List.Skip(model.Page * model.PageSize).Take(model.PageSize).ToList();
            return APIReturn.OK.SetData("list", result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] BlogViewModel model)
        {
            model.Id = this.blogsBLL.List.Count + 1;
            this.blogsBLL.List.Add(model);
            return APIReturn.OK.SetData("detail", model);
        }

        [HttpPost("edit")]
        public IActionResult Edit([FromBody] BlogViewModel model)
        {
            var result = this.blogsBLL.List.FirstOrDefault(f => f.Id == model.Id);
            if (result == null)
                return APIReturn.NotFound;

            return APIReturn.OK.SetData("detail", model);
        }
    }
}
