using ApplicationCore;
using DomainsModel.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class TagRepository: Repository<Tag>, ITagRepository
    {
        private DatabaseContext context { 
           get
            {
            return db as DatabaseContext;
            }
        }
        public TagRepository(DbContext db)
        {
            this.db = db;
        }

    }
}
