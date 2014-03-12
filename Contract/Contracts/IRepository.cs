using System;
using System.Linq;
using Library.Model.Models;

namespace Contract.Contracts
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable GetQuery();

        TEntity GetById(Guid id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        void Detach(TEntity entity);
    }
}
