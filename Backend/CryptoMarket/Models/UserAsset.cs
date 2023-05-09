using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMarket.Models
{
    public class UserAsset
    {
        [Key]
        public Guid AssetId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User Id { get; set; }
        [Required]
        [ForeignKey("CurrencyId")]
        public virtual Currency CoinId { get; set; }
        [Required]
        [Column(TypeName = "decimal(36, 18)")]
        public decimal AvailableBalance { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifyTime { get; set; }

        public UserAsset()
        {
            Id = new User();
            CoinId = new Currency();
        }
    }
}
