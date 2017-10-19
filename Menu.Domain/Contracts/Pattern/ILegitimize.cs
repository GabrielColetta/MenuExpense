using Menu.Domain.Validations;

namespace Menu.Domain.Contracts.Pattern
{
    /// <summary>
    /// Permite que a entidade ser legalizada.
    /// </summary>
    /// <typeparam name="TEntity">Entidade.</typeparam>
    public interface ILegitimize<TEntity> where TEntity : class
    {
        void Validate(LegitimizeCandidateBuilder<TEntity> candidate);
    }
}
