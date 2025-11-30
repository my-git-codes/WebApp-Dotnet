using Microsoft.Identity.Client;

namespace WebAppProject.Models.Entities
{
    public class EmployeeDto
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }
}
