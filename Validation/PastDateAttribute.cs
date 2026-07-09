using System.ComponentModel.DataAnnotations;

namespace Employee_and_Skills_Management_App.Validation
{
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dt)
            {
                return dt.Date < DateTime.Today;
            }

            return false;
        }
    }
}
