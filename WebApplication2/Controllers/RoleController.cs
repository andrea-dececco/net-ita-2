using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repository;
using WebApplication2.Repository.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("All")]
        public IActionResult Get() 
        {
            return Ok(_roleRepository.GetRoles());
        }


        [HttpPost]
        public IActionResult Post(string role)
        {
            _roleRepository.Add(role);

            return NoContent();
        }
    }
}
