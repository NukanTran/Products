﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DAL.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            private set;
            get;
        }

        protected ProductsEntities DbContext
        {
            get { return DbFactory.Init(); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = this.DbContext.Set<T>();
        }
 
        public virtual T Add(T entity)
        {
            var res = dbSet.Add(entity);
            DbContext.SaveChanges();
            return res;
        }
        public virtual bool AddRange(IEnumerable<T> entitys)
        {
            foreach(var entity in entitys)
            {
                dbSet.Add(entity);
            }
            return DbContext.SaveChanges() > 0;
        }

        public virtual bool Contains(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).Count() > 0;
        }

        public virtual bool Contains(int id)
        {
            return dbSet.Find(id) != null;
        }

        public virtual int Count(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                return dbSet.Where(expression).Count();
            }
            else
            {
                return dbSet.Count();
            }
        }

        public virtual bool Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return DbContext.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Delete(Expression<Func<T, bool>> expression)
        {
            foreach (var entity in dbSet.Where(expression))
            {
                dbSet.Remove(entity);
            }
            return DbContext.SaveChanges() > 0;
        }

        public virtual bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return DbContext.SaveChanges() > 0;
        }

        public virtual T Get(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                return QueryIncludes(includes).First(expression);
            }
            else
            {
                return dbSet.First(expression);
            }
        }

        public virtual T Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                return QueryIncludes(includes);
            }
            else
            {
                return dbSet.AsEnumerable();
            }
        }

        public virtual IEnumerable<T> GetListPaging(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, out int total, int page = 0, int size = 50, Expression<Func<T, bool>> expression = null, string[] includes = null)
        {
            IQueryable<T> res;
            if (includes != null && includes.Count() > 0)
            {
                var query = QueryIncludes(includes).AsQueryable();
                res = expression == null ? query : query.Where(expression);
            }
            else
            {
                res = expression == null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();
            }
            total = res.Count();
            res = orderBy(res);
            res = res.Skip(page * size).Take(size);
            return res;
        }

        public virtual bool Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                return QueryIncludes(includes).Where(expression);
            }
            else
            {
                return dbSet.Where(expression).AsEnumerable();
            }
        }

        protected IQueryable<T> QueryIncludes(string[] includes)
        {
            var query = DbContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
