using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Modify(TEntity model);
        void Delete(TEntity model);
        void DeleteById(object id);
    }
}
