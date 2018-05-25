using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [Display(Name = "Unit of Measurement")]
        public string UOM { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImage { get; set; }
    }
}
