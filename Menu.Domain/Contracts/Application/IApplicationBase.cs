using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Menu.Domain.Contracts.Application
{
    public interface IApplicationBase<TEntityModel, TEntity> : IDisposable 
        where TEntityModel : class, new() 
        where TEntity : IEntity
    {
        void Create(TEntityModel model);
        void Delete(long id);
        TEntityModel GetById(long id);
        TEntityModel GetById(long id, Expression<Func<TEntity, TEntityModel>> parameters);
        IEnumerable<TEntityModel> GetPaginated(int page);
        IEnumerable<TEntityModel> GetPaginated(int page, Expression<Func<TEntity, TEntityModel>> parameters);
    }
}
