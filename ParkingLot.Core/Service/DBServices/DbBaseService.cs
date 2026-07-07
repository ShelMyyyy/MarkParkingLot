using Microsoft.EntityFrameworkCore;
using ParkingLot.Core.Service.Interface;
using System.Linq.Expressions;

namespace ParkingLot.Core.Service.DBServices
{
    public class DbBaseService<TContext> : IDbBaseService where TContext : DbContext
    {
        public readonly TContext DbContext;
        public DbBaseService(TContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            DbContext.Set<T>().Add(entity);
            Commit();
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            DbContext.Set<T>().AddRange(entities);
            Commit();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            if (entity == null) throw new Exception("t is null");
            DbContext.Set<T>().Attach(entity);
            DbContext.Set<T>().Remove(entity);
            Commit();
        }

        public void Delete<T>(int id) where T : class
        {
            T t = DbContext.Set<T>().Find(id);
            if (t == null) throw new Exception("t is null");
            DbContext.Set<T>().Remove(t);
        }

        public T Find<T>(int id) where T : class
        {
            var result = DbContext.Set<T>().Find(id);
            if (result == null) throw new Exception("t is null");
            return result;
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return DbContext.Set<T>().Where(funcWhere);
        }

        public void Update<T>(T entity) where T : class
        {
            if (entity == null) throw new Exception("t is null");

            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }

        public void Update<T>(IEnumerable<T> entityList) where T : class
        {
            foreach (var item in entityList)
            {
                DbContext.Set<T>().Attach(item);
                DbContext.Entry(item).State = EntityState.Modified;
            }
            Commit();
        }
    }
}
