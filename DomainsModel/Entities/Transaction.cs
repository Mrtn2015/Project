﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Tran_Id { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Status { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string PaymentType { get; set; }
        public int UserId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual User User { get; set; }
    }
}
