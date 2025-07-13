using Microsoft.AspNetCore.Mvc;
using neosoftCrudApis.Models;
using neosoftCrudApis.Services;

namespace neosoftCrudApis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound(new { message = "Employee not found." });

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _employeeService.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _employeeService.Update(id, employee);
            if (!success)
                return NotFound(new { message = "Employee not found." });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _employeeService.Delete(id);
            if (!success)
                return NotFound(new { message = "Employee not found." });

            return NoContent();
        }
    }
}
