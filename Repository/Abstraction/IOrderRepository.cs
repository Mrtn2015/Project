using DomainsModel.Entities;
using DomainsModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface IOrderRepository : IRepository<Order>
    {
        int SaveCart(Cart model);
        void PlaceOrder(TransactionModel model);
    }
}
