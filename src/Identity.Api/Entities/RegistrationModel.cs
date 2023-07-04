using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Entities
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get;  set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get;  set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}
