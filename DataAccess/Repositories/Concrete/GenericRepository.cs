using DataAccess.Repositories.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity 
{
    protected readonly DbContext dbContext;
    public GenericRepository(DbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    protected DbSet<TEntity> entity => dbContext.Set<TEntity>();


    #region Add
    public virtual int Add(TEntity entity)
    {
        this.entity.Add(entity);
        return dbContext.SaveChanges();
    }

    public virtual int Add(IEnumerable<TEntity> entities)
    {
        entity.AddRange(entities);
        return dbContext.SaveChanges();
    }

    public virtual async Task<int> AddAsync(TEntity entity)
    {
        await this.entity.AddAsync(entity);
        return await dbContext.SaveChangesAsync();
    }

    public virtual async Task<int> AddAsync(IEnumerable<TEntity> entities)
    {
        await entity.AddRangeAsync(entities);
        return await dbContext.SaveChangesAsync();
    }
    #endregion

    #region Update
    public virtual int Update(TEntity entity)
    {
        this.entity.Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;

        return dbContext.SaveChanges();
    }

    public virtual async Task<int> UpdateAsync(TEntity entity)
    {
        this.entity.Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;

        return await dbContext.SaveChangesAsync();
    }
    #endregion

    #region Delete

    public virtual int Delete(TEntity entity)
    {
        this.entity.Remove(entity);

        return dbContext.SaveChanges();
    }

    public virtual int Delete(int id)
    {
        var entity = this.entity.Find(id);
        return Delete(entity);
    }

    public virtual Task<int> DeleteAsync(TEntity entity)
    {

        this.entity.Remove(entity);

        return dbContext.SaveChangesAsync();
    }

    public virtual Task<int> DeleteAsync(int id)
    {
        var entity = this.entity.Find(id);
        return DeleteAsync(entity);
    }

    public virtual bool DeleteRange(Expression<Func<TEntity, bool>> predicate)
    {
        dbContext.RemoveRange(entity.Where(predicate));
        return dbContext.SaveChanges() > 0;
    }

    public virtual async Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate)
    {
        dbContext.RemoveRange(predicate);
        return await dbContext.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await entity.FindAsync(id);
    }

    public virtual TEntity GetById(int id)
    {
        return entity.Find(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await entity.ToListAsync();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return entity.ToList();
    }

    public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await entity.FirstAsync(expression);
    }

    public async Task<List<TEntity>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await entity.Where(expression).ToListAsync();
    }

    public TEntity GetByExpression(Expression<Func<TEntity, bool>> expression)
    {
        return entity.First(expression);
    }

    public List<TEntity> GetListByExpression(Expression<Func<TEntity, bool>> expression)
    {
        return entity.Where(expression).ToList();
    }

    #endregion

}
