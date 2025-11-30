using Microsoft.AspNetCore.Mvc;
using WebAppProject.Data;

namespace WebAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(Models.Entities.EmployeeDto employeeDto)
        {
            var employee = new Models.Entities.Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                HireDate = employeeDto.HireDate
            };
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetAllEmployees), new { id = employee.Id }, employee);
        }
    }
}
