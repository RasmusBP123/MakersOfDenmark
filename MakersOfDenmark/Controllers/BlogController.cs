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

        [HttpPost("uploadFile"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    await using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }
    }
}
