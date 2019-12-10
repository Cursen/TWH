using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TWH.Entities;
using TWH.Repository;

namespace TWH.Services
{
    public abstract class BaseService<TEntity, TEntityIdType> : IDisposable where TEntity : BaseEntityID<TEntityIdType>, new()
    {
        public UnitOfWork unitOfWork { get; set; }
        public BaseRepository<TEntity, TEntityIdType> Repository { get; set; }

        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (unitOfWork != null)
                unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }
        public virtual void SaveChanges()
        {
            Repository.SaveChanges();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            Repository.GetAll();
        }
        public virtual IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.SearchFor(predicate);
        }
        public virtual TEntity GetById(TEntityIdType id)
        {
            return Repository.GetById(id);
        }
        public virtual void Add(TEntity entity)
        {
            Repository.Add(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }
    }
}
