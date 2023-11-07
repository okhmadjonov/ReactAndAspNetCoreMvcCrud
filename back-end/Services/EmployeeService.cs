using back_end.DataContext;
using back_end.Models;
using back_end.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Employee> Add(Employee entity)
        {
              _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return  entity;
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
             _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Edit(int id, Employee request)
        {
            var employee = await _context.Employees.FindAsync(id);
            employee.ID = request.ID;
            employee.Name = request.Name;
            employee.Age = request.Age;
            employee.IsActive = request.IsActive;

            await _context.SaveChangesAsync();
            return employee;

        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
        
                return employee;
            
        }
    }
}
