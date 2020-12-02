using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Controllers
{
    [Route("api/[controller]")]
    public class WorkshopController : Controller
    {
        private readonly IWorkshopService service;

        public WorkshopController(IWorkshopService service)
        {
            this.service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllApproved()
        {
            var workshops = await service.GetAllApproved();
            return Ok(workshops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var workshop = await service.GetById(id);
            return Ok(workshop);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateWorkshopViewModel workshop)
        {
            await service.Create(workshop);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }

        [HttpGet("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleApprovedStateOfWorkshop(Guid id)
        {
            var workshop = await service.ToggleApprovedStateOfWorkshop(id);
            return Ok(workshop);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetAllPendingWorkshops()
        {
           var pendingWorkshops = await service.GetAllPending();
            return Ok(pendingWorkshops);
        }
    }
}
