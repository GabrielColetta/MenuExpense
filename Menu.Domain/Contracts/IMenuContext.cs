using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.Domain.Contracts
{
    /// <summary>
    /// extração da interface do contexto para possíveis troca de framework de persistência.
    /// </summary>
    public interface IMenuContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
