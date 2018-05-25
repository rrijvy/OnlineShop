using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }
        public string PurchaseNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SupplierId { get; set; }
        public double Discount { get; set; }
        public List<PurchaseDetail> PurchaseDetail { get; set; }
        public Supplier Supplier { get; set; }
    }
}
