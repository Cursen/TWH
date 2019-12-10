using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TWH.Entities;

namespace TWH.Repository
{
    public abstract class BaseRepository<TEntity, TEntityIdType> : IRepository<TEntity, TEntityIdType> where TEntity : BaseEntityID<TEntityIdType>, new()
    {
        public UnitOfWork _unitOfWork { get;set; }
        protected DataContext DbContext
        {
            get
            {
                return _unitOfWork.DbContext;
            }
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();

            GC.SuppressFinalize(this);
        }
        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }
        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public TEntity GetById(TEntityIdType id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

    }
}
