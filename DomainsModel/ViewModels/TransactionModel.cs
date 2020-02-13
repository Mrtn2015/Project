using DomainsModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace DomainsModel.ViewModels
{
    public class TransactionModel:Transaction
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
