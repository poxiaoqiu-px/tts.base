using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace tts.extends.entityframework
{
    public class BaseManager<TEntity, TPrimaryKey> : DomainService, IBaseManager<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        protected readonly IRepository<TEntity, TPrimaryKey> _repository;

        public BaseManager(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }

        #region help method

        public IRepository<T, TKey> Repository<T, TKey>() where T : BaseEntity<TKey>
        {
            return IocManager.Instance.Resolve<IRepository<T, TKey>>();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity<int>
        {
            return IocManager.Instance.Resolve<IRepository<T>>();
        }

        #endregion

        public virtual int Count()
        {
            return _repository.Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Count(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.CountAsync(predicate);
        }

        public virtual async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public virtual void Delete(TPrimaryKey id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _repository.Delete(predicate);
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await _repository.DeleteAsync(predicate);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return _repository.FirstOrDefault(id);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await _repository.FirstOrDefaultAsync(id);
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return _repository.Get(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return _repository.GetAllIncluding(propertySelectors);
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetAllList(predicate);
        }

        public virtual List<TEntity> GetAllList()
        {
            return _repository.GetAllList();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAllListAsync(predicate);
        }

        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
        {
            return _repository.InsertAndGetId(entity);
        }

        public virtual async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return await _repository.InsertAndGetIdAsync(entity);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            return _repository.InsertOrUpdate(entity);
        }

        public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            return _repository.InsertOrUpdateAndGetId(entity);
        }

        public virtual async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            return await _repository.InsertOrUpdateAndGetIdAsync(entity);
        }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return await _repository.InsertOrUpdateAsync(entity);
        }

        public virtual TEntity Load(TPrimaryKey id)
        {
            return _repository.Load(id);
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.LongCount(predicate);
        }

        public virtual long LongCount()
        {
            return _repository.LongCount();
        }

        public virtual async Task<long> LongCountAsync()
        {
            return await _repository.LongCountAsync();
        }

        public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.LongCountAsync(predicate);
        }

        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return _repository.Query(queryMethod);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Single(predicate);
        }

        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleAsync(predicate);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            return _repository.Update(id, updateAction);
        }

        public async Task UpdateAsync(Expression<Func<TEntity, bool>> predicate, Action<TEntity> updateAction)
        {
            var entities = await GetAllListAsync();

            foreach (var entity in entities)
            {
                updateAction(entity);
                //_repository.Update(entity);//TODO:???
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            return await _repository.UpdateAsync(id, updateAction);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<List<TEntity>> GetAllListWithOrderByAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderby)
        {
            var query = _repository.GetAll()
                .Where(predicate)
                .OrderBy(orderby);
            return await query.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllListWithOrderByDescAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, string>> orderby)
        {
            var query = _repository.GetAll()
                .Where(predicate)
                .OrderByDescending(orderby);
            return await query.ToListAsync();
        }

        public bool InsertAll(List<TEntity> entities)
        {
            entities?.ForEach(entity => Insert(entity));
            return true;
        }

        public bool UpdataAll(List<TEntity> entities)
        {
            entities?.ForEach(entity => Update(entity));
            return true;
        }
    }

    public class BaseManager<TEntity> : BaseManager<TEntity, int> where TEntity : BaseEntity<int>
    {
        public BaseManager(IRepository<TEntity> repository)
            : base(repository)
        {

        }

    }

}