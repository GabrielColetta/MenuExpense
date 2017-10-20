using Menu.AutoMapper;
using Menu.Domain.Contracts;
using Menu.Domain.Contracts.Pattern;
using Menu.Exceptions.Handlers;
using Menu.Resources.ResourcesFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace Menu.Application
{
    /// <summary>
    /// Abstração base de todas classes da camada de aplicação.
    /// </summary>
    /// <typeparam name="TEntityModel">A classe model que representa a entidade que a aplicação presta serviço.</typeparam>
    /// <typeparam name="TEntity">A entidade que a aplicação presta serviço.</typeparam>
    public abstract class ApplicationBase<TEntityModel, TEntity> : IDisposable
        where TEntityModel : IEntityModel
        where TEntity : class, IEntity
    {
        protected ApplicationBase(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _erros = new List<string>();
            ResourceManager rm = new ResourceManager(typeof(EntitiesNames));
            _entityName = rm.GetString(nameof(TEntity));
        }

        protected IContext _context { get; set; }
        protected IEnumerable<string> _erros { get; set; }
        protected string _entityName { get; set; }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Método base para inserção de uma nova entidade.
        /// </summary>
        /// <param name="model">Modelo a se tornar uma nova entidade.</param>
        public virtual void Create(TEntityModel model)
        {
            if (model != null)
            {
                TEntity entity = ValidateEntity(model);
                entity.IncludedDate = DateTime.Now;

                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Método base para atualização de uma entidade existente.
        /// </summary>
        /// <param name="model">Modelo para atualizar uma entidade existente.</param>
        public virtual void Update(TEntityModel model)
        {
            if (model != null)
            {
                var entity = _context.Set<TEntity>().Find(model.Id);
                TEntity changedEntity = ValidateEntity(model);

                entity = changedEntity;
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
            }
            throw new BusinessException(ErrorMessage.ValuesIsEmpty);
        }

        /// <summary>
        /// Método base para exclusão de uma entidade.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        public virtual void Delete(long id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Find(id);
                if (entity == null)
                {
                    throw new BusinessException(string.Format(_entityName, ErrorMessage.NotFound, 404));
                }
                _context.Set<TEntity>().Update(entity);
                entity.IsDeleted = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Método base para encontrar entidade por id.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Retorna a entidade.</returns>
        public virtual TEntityModel GetById(long id)
        {
            TEntity result = _context.Set<TEntity>()
                .Where(item => item.Id == id)
                .FirstOrDefault();

            if (result != null)
            {
                return MapToModel(result);
            }
            throw new BusinessException(string.Format(_entityName, ErrorMessage.NotFound, 404));
        }

        /// <summary>
        /// Método base para encontrar entidade por id.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <param name="parameters">Itens a ser filtrado no select.</param>
        /// <returns>Retorna a entidade.</returns>
        public virtual TEntityModel GetById(long id, Expression<Func<TEntity, TEntityModel>> parameters)
        {

            TEntityModel result = _context.Set<TEntity>()
                .Where(item => item.Id == id)
                .Select(parameters)
                .FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            throw new BusinessException(string.Format(_entityName, ErrorMessage.NotFound, 404));
        }

        /// <summary>
        /// Páginação base da entidade.
        /// </summary>
        /// <param name="page">Qual a página ele esta atualmente.</param>
        /// <returns>Retorna a páginação das entidades.</returns>
        public virtual IEnumerable<TEntityModel> GetPaginated(int page)
        {
            int index = page * 12;
            ICollection<TEntity> result = _context.Set<TEntity>().Skip(index).Take(12).ToList();

            if (result != null)
            {
                ICollection<TEntityModel> formattedResult = new List<TEntityModel>();
                foreach (var item in result)
                {
                    formattedResult.Add(MapToModel(item));
                }
                return formattedResult;
            }
            throw new BusinessException(string.Format(_entityName, ErrorMessage.NotFound), 404);
        }

        /// <summary>
        /// Páginação base da entidade.
        /// </summary>
        /// <param name="page">Qual a página ele esta atualmente.</param>
        /// <param name="parameters">Itens a ser filtrado no select.</param>
        /// <returns>Retorna a páginação das entidades.</returns>
        public virtual IEnumerable<TEntityModel> GetPaginated(int page, Expression<Func<TEntity, TEntityModel>> parameters)
        {
            int index = page * 12;
            ICollection<TEntityModel> result =
                _context.Set<TEntity>()
                .Skip(index)
                .Take(12)
                .Select(parameters)
                .ToList();

            return result;
        }

        /// <summary>
        /// Validação base para novas entidade a ser inserida no banco, sobreescrever para validações especificas.
        /// </summary>
        /// <param name="object">objeto a ser inserido.</param>
        /// <returns>retorna o resultado da validação.</returns>
        protected virtual TEntity ValidateEntity(TEntityModel @object)
        {
            try
            {
                var newEntity = MapToEntity(@object);
                newEntity.Validate(_erros);
                if (_erros.Any())
                {
                    throw new BusinessException(string.Format(_entityName, ErrorMessage.NotValid));
                }
                return newEntity;
            }
            catch (Exception)
            {
                throw new MapperException(ErrorMessage.InvalidValueForMap);
            }
        }

        protected virtual TEntityModel MapToModel(TEntity entity)
        {
            if (entity != null)
            {
                return MapBase<TEntityModel, TEntity>.MapEntityModel(entity);
            }
            throw new BusinessException(ErrorMessage.ValuesIsEmpty);
        }

        protected virtual TEntity MapToEntity(TEntityModel model)
        {
            if (model != null)
            {
                return MapBase<TEntityModel, TEntity>.MapEntity(model);
            }
            throw new BusinessException(ErrorMessage.ValuesIsEmpty);
        }
    }
}
