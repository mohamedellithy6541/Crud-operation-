
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class RegisterViewModeld
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required(ErrorMessage="Email is requird ")]
        [EmailAddress(ErrorMessage ="invalied Emails")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="pls confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password does not matched ")]
        public string ConforimPassword { get; set; }    
        public bool IsAgree { get; set; }    
    }
}
