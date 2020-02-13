using ApplicationCore;
using DomainsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public DatabaseContext Context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public CategoryRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
