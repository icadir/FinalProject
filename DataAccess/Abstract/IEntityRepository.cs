using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    // Generic constraint( generic kısıt)
    // class : referans tip olabilir.
    // IEntity : I entity olabilir veya Ientityden implement edilmiş bir referans tip olabilir
    //new :  newlenebilir bir nesne olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new ()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
