using ApplicationCore;
using DomainsModel.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IProductRepository ProductRepo { get; }
        IOrderRepository OrderRepo { get; }
        ITagRepository TagRepo { get; }
        int SaveChanges();
        Task<List<Role>> ListRoles();
    }
}
