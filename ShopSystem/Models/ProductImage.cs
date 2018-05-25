using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageFileName { get; set; }
        public Product Product { get; set; }
    }
}
