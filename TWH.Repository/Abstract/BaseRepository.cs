using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TWH.Entities;

namespace TWH.Repository
{
    public abstract class BaseRepository<TEntity, TEntityIdType> : IDisposable where TEntity : BaseEntityID<TEntityIdType>, new()
    {
        public UnitOfWork unitOfWork { get;set; }
        protected DataContext DbContext
        {
            get
            {
                return unitOfWork.DbContext;
            }
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();

            GC.SuppressFinalize(this);
        }
        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(TEntityIdType id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Any(predicate);
        }
        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
