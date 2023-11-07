using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Repositories
{
    public interface IEmployeeRepository
    {

        Task<ActionResult<IEnumerable<Employee>>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee entity);
        Task<Employee> Edit(int id, Employee employee);
        Task Delete(int id);


    }
}
