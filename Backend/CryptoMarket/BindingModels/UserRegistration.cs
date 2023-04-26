using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.BindingModels
{
    public class UserRegistration
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
