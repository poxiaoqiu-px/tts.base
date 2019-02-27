using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace tts.extends.entityframework
{
    public interface IBaseManager<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        IRepository<T, TKey> Repository<T, TKey>() where T : BaseEntity<TKey>;

        IRepository<T> Repository<T>() where T : BaseEntity<int>;

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync();

        void Delete(TEntity entity);

        void Delete(TPrimaryKey id);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        Task DeleteAsync(TPrimaryKey id);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task DeleteAsync(TEntity entity);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        TEntity Get(TPrimaryKey id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetAllList();

        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllListWithOrderByAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderby);

        Task<List<TEntity>> GetAllListWithOrderByDescAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderby);

        Task<List<TEntity>> GetAllListAsync();

        Task<TEntity> GetAsync(TPrimaryKey id);

        TEntity Insert(TEntity entity);

        bool InsertAll(List<TEntity> entities);

        TPrimaryKey InsertAndGetId(TEntity entity);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        TEntity InsertOrUpdate(TEntity entity);

        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        TEntity Load(TPrimaryKey id);

        long LongCount(Expression<Func<TEntity, bool>> predicate);

        long LongCount();

        Task<long> LongCountAsync();

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);

        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, Action<TEntity> updateAction);

        bool UpdataAll(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        Task<TEntity> UpdateAsync(TEntity entity);
    }

    public interface IBaseManager<TEntity> : IBaseManager<TEntity, int> where TEntity : BaseEntity<int>
    {

    }

}
