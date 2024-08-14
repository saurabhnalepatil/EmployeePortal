using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmployee = await _employeeRepository.GetAllEmployees();
            return Ok(allEmployee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee vm)
        {
            await _employeeRepository.SaveEmployee(vm);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, Employee obj)
        {
            await _employeeRepository.updateEmployee(id, obj);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
