using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class DeliveryDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryDetailId { get; set; }

        [Display(Name = "Delivery Id")]
        public int DeliveryId { get; set; }

        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Delivery Delivery { get; set; }
        public Product Product { get; set; }
    }
}
