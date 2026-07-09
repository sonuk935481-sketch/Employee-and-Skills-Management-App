using Employee_and_Skills_Management_App.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_and_Skills_Management_App.Services
{
    public interface IEmployeeService
    {
        Task SaveEmployeeAsync(EmployeeSaveDto dto);

        Task<Employee?> GetEmployeeAsync(int id);

        Task<List<Employee>> GetAllEmployeesAsync();

        Task<List<Skills>> GetAllSkillsAsync();

        Task UpdateEmployeeAsync(Employee employee, IEnumerable<int> skillIds);

        Task DeleteEmployeeAsync(int id);
    }
}
