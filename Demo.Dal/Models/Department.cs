using System.ComponentModel.DataAnnotations;

namespace Demo.Dal.Models
{
    public class Department
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
            [Required(ErrorMessage = " name is Resquird")]
        public string? Name { get; set; }
        public DateTime DataOfCreation { get; set; }
        ICollection<Employee>? employees { get; set; } = new HashSet<Employee>();
    }
}
