using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string ShippingAddress { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ContactNo { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
