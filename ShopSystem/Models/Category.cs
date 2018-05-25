using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string Description { get; set; }

        [Display(Name = "Sorting Order")]
        public float SortingOrder { get; set; }
        public int Discontinued { get; set; }
        public List<Product> Products { get; set; }
    }
}
