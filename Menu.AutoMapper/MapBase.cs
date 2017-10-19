using AutoMapper;
using Menu.Domain.Contracts;
using Menu.Domain.Contracts.Pattern;

namespace Menu.AutoMapper
{
    public class MapBase<TEntityModel, TEntity> 
        where TEntityModel : IEntityModel 
        where TEntity : class, IEntity
    {
        public static TEntity MapEntity(TEntityModel model)
        {
            return Mapper.Map<TEntity>(model);
        }

        public static TEntityModel MapEntityModel(TEntity entity)
        {
            return Mapper.Map<TEntityModel>(entity);
        }
    }
}
