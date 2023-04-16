using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.BindingModels
{
    public class UserLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
