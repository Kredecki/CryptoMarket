using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMarket.Models
{
    public class SpotTradingOrder
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(10)]
        public string OrderType { get; set; }
        [Required]
        [Column(TypeName = "decimal(36, 18)")]
        public decimal OrderPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(36, 18)")]
        public decimal OrderValue { get; set; }
        [Required]
        [Column(TypeName = "decimal(36, 18)")]
        public decimal OrderQty { get; set; }
        [Required]
        [ForeignKey("SpotTradingPairId")]
        public int SpotTradingPairId { get; set; }
        [Required]
        [MaxLength(5)]
        public string Direction { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifyTime { get; set; }

        public SpotTradingOrder()
        {
            OrderType = "";
            Direction = "";
            UserId = Guid.NewGuid();
        }
    }
}
