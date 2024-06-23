using System.Linq.Expressions;

namespace StudentManagementSystem.DataAccess.Abstract
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
    }
}

