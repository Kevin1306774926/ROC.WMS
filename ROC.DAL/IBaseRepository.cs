using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ROC.DAL
{
    public interface IBaseRepository<T> where T:class,new()
    {
        T Get(object id);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> Get<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderBy,
            int pageSize, int pageIndex, out int totalCount, bool isAsc);
        IQueryable<T> Get(Expression<Func<T, bool>> whereLambda, string orderName,
            int pageSize, int pageIndex, out int totalCount, bool isAsc);
        /// <summary>
        /// 查询总数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int Add(params T[] entities);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int Update(params T[] entities);
    }
}
