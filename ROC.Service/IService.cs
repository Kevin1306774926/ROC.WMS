using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROC.Modles;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ROC.Service
{
    public interface IService<T> where T : class, new()
    {
        DbContext DB { get; }
        T Get(params Object[] id);
        //查询
        IQueryable<T> Get(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> Get(Expression<Func<T, bool>> whereLambda, string include);
        //分页查询
        IQueryable<T> Get<S>(
            Expression<Func<T, bool>> whereLambada,
            Expression<Func<T, S>> orderBy,
            int pageSize,
            int pageIndex,
            out int totalCount,
            bool isASC);
        //分页查询
        IQueryable<T> Get(
            Expression<Func<T, bool>> whereLambada,
            string orderName,
            int pageSize,
            int pageIndex,
            out int totalCount,
            bool isASC);

        //查询总数量
        int Count(Expression<Func<T, bool>> predicate);

        //添加
        T Add(T entity);

        //批量添加
        int Add(params T[] entities);

        //删除
        int Delete(T entity);

        //批量删除
        int Delete(Expression<Func<T, bool>> whereLambda);

        //更新
        T Update(T entity);

        //批量更新
        int Update(params T[] entities);
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
