using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class SalesOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesOrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int ApplicationUserId { get; set; }
        public double Discount { get; set; }

        public string ShipAddressLine1 { get; set; }
        public string ShipAddressLine2 { get; set; }
        public string ShipAddressLine3 { get; set; }

        public string BillAddressLine1 { get; set; }
        public string BillAddressLine2 { get; set; }
        public string BillAddressLine3 { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
        public ApplicationUser User { get; set; }
    }
}
