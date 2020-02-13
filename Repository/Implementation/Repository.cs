using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext db { get; set; }
        
        public void Add(TEntity model)
        {
            db.Set<TEntity>().Add(model);
        }

        public void Delete(TEntity model)
        {
            if (model != null) { 
            db.Set<TEntity>().Remove(model);
            }
        }

        public void DeleteById(object id)
        {
            var entity = db.Set<TEntity>().Find(id);
            if (entity != null)
                db.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(object id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Modify(TEntity model)
        {
            db.Entry<TEntity>(model).State = EntityState.Modified;
        }
    }
}
