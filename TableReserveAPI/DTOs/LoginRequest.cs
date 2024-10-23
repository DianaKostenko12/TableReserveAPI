using System.ComponentModel.DataAnnotations;

namespace TableReserveAPI.DTOs
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
