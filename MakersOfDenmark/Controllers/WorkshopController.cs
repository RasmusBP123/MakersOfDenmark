using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Controllers
{
    [Route("api/workshop")]
    public class WorkshopController : Controller
    {
        private readonly IWorkshopService service;

        public WorkshopController(IWorkshopService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var workshops = await service.GetAll();
            return Ok(workshops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var workshop = await service.GetById(id);
            return Ok(workshop);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateWorkshopViewModel workshop)
        {
            await service.Create(workshop);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }
    }
}
