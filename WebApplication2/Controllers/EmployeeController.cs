using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repository;
using WebApplication2.Repository.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("All")]
        public IActionResult Get() 
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            return Ok(_employeeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            _employeeRepository.AddEmployee(employee);

            return NoContent();
        }
    }
}
