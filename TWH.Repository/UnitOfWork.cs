using System;
using TWH.Entities;
using System.Collections.Generic;
using System.Text;
namespace TWH.Repository
{
    public class UnitOfWork : IDisposable
    {
        public DataContext DbContext { get; set; }
        public UnitOfWork()
        {
            DbContext = DataContext.Create();
        }
        public int Complete()
        {
            return DbContext.SaveChanges();
        }
        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
