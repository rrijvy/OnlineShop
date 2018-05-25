using ShopSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Display(Name = "Sales Order")]
        public int SalesOrderId { get; set; }
        public int ApplicationUserId { get; set; }
        public double Amount { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public ApplicationUser User { get; set; }
    }
}
