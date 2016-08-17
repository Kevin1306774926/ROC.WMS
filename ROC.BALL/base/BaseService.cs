using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using ROC.DAL;

namespace ROC.BLL
{
    public abstract class BaseService<T> : IDisposable where T : class,new()
    {
        //数据层统一访问入口工厂属性
        private IDbSessionFactory _DbSessionFactory;

        public IDbSessionFactory DbSessionFactory
        {
            get
            {
                if (_DbSessionFactory == null)
                {
                    _DbSessionFactory = new DbSessionFactory();
                }
                return _DbSessionFactory;
            }
            set { _DbSessionFactory = value; }
        }

        //数据层统一访问入口属性
        private IDbSession _DbSessionContext;

        public IDbSession DbSessionContext
        {
            get
            {
                if (_DbSessionContext == null)
                {
                    _DbSessionContext = DbSessionFactory.GetCurrentDbSession();
                }
                return _DbSessionContext;
            }
            set { _DbSessionContext = value; }
        }

        //当前Repository,在子类中实现--通过一个抽象方法在构造函数中设置
        protected IBaseRepository<T> CurrentRepository;

        //借助此方法在子类中的重写，为XXXService设置当前Repository
        public abstract bool SetCurrentRepository();

        public BaseService()
        {
            this.DisposableObjects = new List<IDisposable>();
            this.SetCurrentRepository();
        }

        public T Get(object id)
        {
            return this.CurrentRepository.Get(id);
        }

        //查询
        public IQueryable<T> Get(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentRepository.Get(whereLambda);
        }

        public IQueryable<T> Get<S>(
            Expression<Func<T, bool>> whereLambada,
            Expression<Func<T, S>> orderBy,
            int pageSize,
            int pageIndex,
            out int totalCount,
            bool isASC)
        {
            return this.CurrentRepository.Get<S>(
                whereLambada,
                orderBy,
                pageSize,
                pageIndex,
                out totalCount,
                isASC);
        }

        public IQueryable<T> Get(
            Expression<Func<T, bool>> whereLambada,
            string orderName,
            int pageSize,
            int pageIndex,
            out int totalCount,
            bool isASC)
        {
            return this.CurrentRepository.Get(
                whereLambada,
                orderName,
                pageSize,
                pageIndex,
                out totalCount,
                isASC);
        }

        //查询总数量
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return this.CurrentRepository.Count(predicate);
        }
        
        //添加
        public T Add(T entity)
        {
            this.CurrentRepository.Add(entity);
            DbSessionContext.SaveChanges();
            return entity;
        }

        //批量添加
        public int Add(params T[] entities)
        {
            return this.CurrentRepository.Add(entities);
        }

        //删除
        public int Delete(T entity)
        {
            this.CurrentRepository.Delete(entity);
            return DbSessionContext.SaveChanges();
        }

        //批量删除
        public int Delete(Expression<Func<T, bool>> whereLambda)
        {
            this.CurrentRepository.Delete(whereLambda);
            return DbSessionContext.SaveChanges();
        }

        //更新
        public T Update(T entity)
        {
            this.CurrentRepository.Update(entity);
            if (this.DbSessionContext.SaveChanges() <= 0)
            {
                return null;
            }
            return entity;
        }

        //批量更新
        public int Update(params T[] entities)
        {
            return this.CurrentRepository.Update(entities);
        }

        public IList<IDisposable> DisposableObjects { get; private set; }

        protected void AddDisposableObject(object obj)
        {
            IDisposable disposable = obj as IDisposable;
            if (disposable != null)
            {
                this.DisposableObjects.Add(disposable);
            }
        }

        public void Dispose()
        {
            foreach (IDisposable obj in this.DisposableObjects)
            {
                if (obj != null)
                {
                    obj.Dispose();
                }
            }
        }
    }
}
