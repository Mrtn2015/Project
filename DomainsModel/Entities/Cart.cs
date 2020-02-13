using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainsModel.Entities
{
    public class Cart
    {
        public Cart()
        {
            Items = new HashSet<CartItem>();
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int CartId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
        public virtual User User { get; set; }
    }
}
