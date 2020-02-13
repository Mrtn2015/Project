using DomainsModel.Entities;
using DomainsModel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class OrderRepository:IOrderRepository
    {
        public OrderRepository(DbContext db)
        {

        }

        public void Add(Order model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order model)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Modify(Order model)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(TransactionModel model)
        {
            throw new NotImplementedException();
        }

        public int SaveCart(Cart model)
        {
            throw new NotImplementedException();
        }
    }
}
