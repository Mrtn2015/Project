﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.ViewModels
{
    
    public class ReceiptModel
    {
        public string TransactionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
    }
}
