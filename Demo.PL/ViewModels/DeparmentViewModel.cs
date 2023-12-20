using Demo.Dal.Models;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class DeparmentViewModel
    {


        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required(ErrorMessage = " name is Resquird")]
        public string? Name { get; set; }
        public DateTime DataOfCreation { get; set; }
        ICollection<Employee>? employees { get; set; } = new HashSet<Employee>();
    }
}
