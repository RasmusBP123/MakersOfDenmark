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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorkshop([FromBody]CreateWorkshopViewModel workshop)
        {
            await service.Create(workshop);
            return Ok();
        }
    }
}
