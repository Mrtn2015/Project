using ApplicationCore;
using DomainsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public ProductRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
