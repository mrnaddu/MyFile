using EmployeeApi.Context;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
           _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Result =  await _context.Employees.ToListAsync();
            if(Result == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Result);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeModel Employee)
        {
            Employee.Id = Guid.NewGuid();
            await _context.Employees.AddAsync(Employee);
            await _context.SaveChangesAsync();
            return Ok(Employee);
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> GetId(Guid id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
    
       public async Task<IActionResult> Update(Guid id, EmployeeModel emp)
        {
            var result = await _context.Employees.FindAsync(id);
            if (result == null)
            {
                return NotFound();

            }
         result.Name= emp.Name;
            result.phone=emp.phone;
            result.Email = emp.Email;
            result.Salary=emp.Salary;
            result.department = emp.department;
           await _context.SaveChangesAsync();
            return Ok(result);

        }

        [HttpDelete]

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(result); 
         }
    }
}
