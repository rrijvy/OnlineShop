using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryId { get; set; }

        [Display(Name = "Sales Order")]
        public int SalesOrderId { get; set; }

        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Delivery No")]
        public string DeliveryNo { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public List<DeliveryDetail> DeliveryDetail { get; set; }
    }
}
