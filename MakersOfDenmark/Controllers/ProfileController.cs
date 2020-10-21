using System.Threading.Tasks;
using Domain.Abstractions.Repositories;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileRepository repository;

        public ProfileController(IProfileRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await repository.DeleteUser(userId);
            return Ok();
        }
    }
}
