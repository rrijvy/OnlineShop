using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models

{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [Display(Name = "Sales Order")]
        public int SalesOrderId { get; set; }

        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [Display(Name = "Unit of Measurement")]
        public string UOM { get; set; }
        public double Discount { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
    }
}
