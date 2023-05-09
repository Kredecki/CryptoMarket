using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CurrencyName { get; set; }
        [Required]
        [MaxLength(5)]
        public string CurrencySymbol { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifyTime { get; set; }

        public Currency()
        {
            CurrencyName = "";
            CurrencySymbol = "";
        }
    }
}
