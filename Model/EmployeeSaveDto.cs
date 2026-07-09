using System;

namespace Employee_and_Skills_Management_App.Model
{
    public class EmployeeSaveDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public int[]? SkillIds { get; set; }
    }
}
