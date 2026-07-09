using System.ComponentModel.DataAnnotations;
using Employee_and_Skills_Management_App.Validation;
namespace Employee_and_Skills_Management_App.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string FirstName { get; set; } 

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; } 

        [Required(ErrorMessage = "Date of birth is required")]
        [PastDate(ErrorMessage = "Date of birth must be in the past")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; } 

        public ICollection<Skills> Skills { get; set; } = new List<Skills>();
    }
}

