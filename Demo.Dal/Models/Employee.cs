using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "maximum char is 50")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int Age { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public int? Departmentid { get; set; }
        public Department? department { get; set; }
    }
}

