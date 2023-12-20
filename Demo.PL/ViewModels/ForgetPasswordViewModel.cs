using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is requird ")]
        [EmailAddress(ErrorMessage = "invalied Emails")]
        public string Email { get; set; }
    }
}
