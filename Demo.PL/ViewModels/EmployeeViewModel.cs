using Demo.Dal.Models;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "maximum char is 50")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(20, 100, ErrorMessage = "range between 20,100 ")]
        public int Age { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int? Departmentid { get; set; }
        public Department? department { get; set; }
    }
}
