using Employee_and_Skills_Management_App.Data;
using Employee_and_Skills_Management_App.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Employee_and_Skills_Management_App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Skills>> GetAllSkillsAsync()
        {
            return await _db.Skills.AsNoTracking().ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _db.Employees.Include(e => e.Skills).AsNoTracking().ToListAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _db.Employees.Include(e => e.Skills).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveEmployeeAsync(EmployeeSaveDto dto)
        {
            // Use EF Core code-first save to insert Employee and link Skills
            var employee = new Employee
            {
                FirstName = dto.FirstName ?? string.Empty,
                LastName = dto.LastName ?? string.Empty,
                DateOfBirth = dto.DateOfBirth,
                Phone = dto.Phone ?? string.Empty
            };

            if (dto.SkillIds != null && dto.SkillIds.Length > 0)
            {
                var skills = await _db.Skills.Where(s => dto.SkillIds.Contains(s.Id)).ToListAsync();
                employee.Skills = skills;
            }

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee, IEnumerable<int> skillIds)
        {
            var skills = await _db.Skills.Where(s => skillIds.Contains(s.Id)).ToListAsync();
            employee.Skills = skills;
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var e = await _db.Employees.FindAsync(id);
            if (e == null) return;
            _db.Employees.Remove(e);
            await _db.SaveChangesAsync();
        }
    }
}
