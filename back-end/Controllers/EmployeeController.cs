using back_end.Models;
using back_end.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll() { 
       
        
            return await _employeeRepository.GetAll();
            //return Ok(employees);
        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {


            var employee = await _employeeRepository.GetById(id);
            return Ok(employee);

        }


        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee) { 
             await _employeeRepository.Add(employee);
            return CreatedAtAction(nameof(GetAll), new { id = employee.ID }, employee);
        }

        [HttpPut("{id}")]
        public async Task<Employee> Edit(int id, Employee employee) 
        {
            return await _employeeRepository.Edit(id, employee);
          
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
             await _employeeRepository.Delete(id);
        }


    }
}
