using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMarket.Models
{
    public class SpotTradingPair
    {
        [Key]
        public int SpotTradingPairId { get; set; }
        [Required]
        [ForeignKey("BaseCurrency")]
        public int BaseCurrencyId { get; set; }
        [Required]
        [ForeignKey("QuoteCurrency")]
        public int QuoteCurrencyId { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifyTime { get; set; }

        public SpotTradingPair()
        {
            BaseCurrency = new Currency();
            QuoteCurrency = new Currency();
        }

        public Currency BaseCurrency { get; set; }
        public Currency QuoteCurrency { get; set; }
    }
}
