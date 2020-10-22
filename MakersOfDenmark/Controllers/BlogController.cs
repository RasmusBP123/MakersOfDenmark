using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Controllers
{
    [Route("api/blog")]
    public class BlogController : Controller
    {
        private readonly IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await service.GetAll();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var blog = await service.GetById(id);
            return Ok(blog);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBlogViewModel blog)
        {
            await service.Create(blog);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }
    }
}
