using System;

namespace Menu.Domain.Contracts.Application
{
    public interface IApplicationBase<TEntityModel, TEntity> : IDisposable 
        where TEntityModel : class, new() 
        where TEntity : IEntity
    {
        void ValidateExistingEntity(TEntity obj);
        void ValidateNewEntity(TEntity obj);
    }
}
