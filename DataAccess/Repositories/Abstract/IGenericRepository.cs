using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    #region Add

    Task<int> AddAsync(TEntity entity);
    int Add(TEntity entity);
    int Add(IEnumerable<TEntity> entities);
    Task<int> AddAsync(IEnumerable<TEntity> entities);

    #endregion


    #region Update

    Task<int> UpdateAsync(TEntity entity);
    int Update(TEntity entity);

    #endregion


    #region Delete

    Task<int> DeleteAsync(TEntity entity);
    int Delete(TEntity entity);
    Task<int> DeleteAsync(int id);
    int Delete(int id);
    bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
    Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

    #endregion


    #region Get

    Task<TEntity> GetByIdAsync(int id);
    TEntity GetById(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> GetAll();
    Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<List<TEntity>> GetListByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    TEntity GetByExpression(Expression<Func<TEntity, bool>> expression);
    List<TEntity> GetListByExpression(Expression<Func<TEntity, bool>> expression);

    #endregion
}
