using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBcontext dBcontext;

        public EmployeesController(ApplicationDBcontext dBcontext)
        {
            this.dBcontext = dBcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dBcontext.Employees.ToList();

            return Ok(allEmployees);
        }


        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeeById(Guid id)
        {
           var employee = dBcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateEmployee(Guid id, UpdateEmployeedto updateEmployeedto)
        {
            var employee = dBcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound(id);
            }

            employee.Name = updateEmployeedto.Name;
            employee.Email = updateEmployeedto.Email;
            employee.Salary = updateEmployeedto.Salary;
            employee.Phone = updateEmployeedto.Phone;
          
            dBcontext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dBcontext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            dBcontext.Employees.Remove(employee);
            dBcontext.SaveChanges();

            return Ok();
        }

        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employeeEnitiy = new Employee()
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary,
            };


            dBcontext.Employees.Add(employeeEnitiy);
            dBcontext.SaveChanges();

            return Ok(employeeEnitiy);
        }

    }
}