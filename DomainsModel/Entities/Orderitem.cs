﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainsModel.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
