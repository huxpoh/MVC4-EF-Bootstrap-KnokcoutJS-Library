using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using Contract.Contracts;
using Library.Model.Models;

namespace Library.EF_DataLayer.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly LibraryContext _context;

        public EfRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Detach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return query;
        }

        public IQueryable GetQuery()
        {
            return _context.Set<TEntity>(); ;
        }

        public virtual TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();

            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            var guid = Guid.Parse(id.ToString());
            var entityToDelete = _context.Set<TEntity>().Find(guid);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            var set = _context.Set<TEntity>();
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                set.Attach(entityToDelete);
            }
            set.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var set = _context.Set<TEntity>();
            var entry = _context.Entry(entityToUpdate);

            if (entry.State == EntityState.Detached)
            {

                var attachedEntity = set.Local.SingleOrDefault(e => e.Id == entityToUpdate.Id);

                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entityToUpdate);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
