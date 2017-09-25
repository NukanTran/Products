using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ProductsEntities Context
        {
            get { return DbFactory.Init(); }
        }
        #endregion

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = Context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual bool Contains(int id)
        {
            return dbSet.Find(id) != null;
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual IQueryable<T> GetListPaging(int page, int size)
        {
            return dbSet.Skip(page * size).Take(size);
        }

        public virtual bool Update(int id, T entity)
        {
            if (Contains(id))
            {
                dbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            return false;
        }
    }
}
