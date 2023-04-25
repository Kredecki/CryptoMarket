using System.ComponentModel.DataAnnotations;

namespace CryptoMarket.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
