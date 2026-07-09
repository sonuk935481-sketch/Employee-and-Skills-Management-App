using System.ComponentModel.DataAnnotations;

namespace Employee_and_Skills_Management_App.Model
{
    public class Skills
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
