using System.Linq.Expressions;

namespace ParkingLot.Core.Service.Interface
{
    public interface IDbBaseService
    {

        #region Query
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : class;

        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;
        #endregion


        #region Insert
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class;


        public void AddRange<T>(IEnumerable<T> entities) where T : class;
        #endregion

        #region Update
        public void Update<T>(T entity) where T : class;

        public void Update<T>(IEnumerable<T> entityList) where T : class;
        #endregion

        #region Delete
        public void Delete<T>(T entity) where T : class;

        public void Delete<T>(int id) where T : class;
        #endregion


        public void Commit();
    }
}
