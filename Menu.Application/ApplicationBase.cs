using Menu.AutoMapper;
using Menu.Domain.Contracts;
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
        protected ApplicationBase(IMenuContext context)
        {
            _context = context;
            _erros = new List<string>();
            ResourceManager rm = new ResourceManager(typeof(EntitiesNames));
            _entityName = rm.GetString(nameof(TEntity));
        }

        protected IMenuContext _context { get; set; }
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
                bool isValid = ValidateNewEntity(model);
                if (isValid)
                {
                    TEntity entity = MapToEntity(model);
                    _context.Set<TEntity>().Add(entity);
                }
                else
                {
                    throw new ApplicationException();
                }
            }
        }
        
        //public virtual void Update(TEntityModel model)
        //{
        //    if (model != null)
        //    {
        //        bool isValid = ValidateExistingEntity(model);
        //        if (isValid)
        //        {
        //        }
        //    }
        //}

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
                    throw new ApplicationException();
                }
                _context.Set<TEntity>().Remove(entity);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Método base para encontrar entidade por id.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <param name="parameters">Itens a ser filtrado no select.</param>
        /// <returns></returns>
        public virtual TEntityModel GetById(long id, Expression<Func<TEntity, TEntityModel>> parameters = null)
        {
            TEntityModel result = default(TEntityModel);
            if (parameters != null)
            {
                result = _context.Set<TEntity>()
                    .Where(item => item.Id == id)
                    .Select(parameters)
                    .FirstOrDefault();
            }
            else
            {
                var initialResult = _context.Set<TEntity>()
                    .Where(item => item.Id == id)
                    .Select(item => item)
                    .FirstOrDefault();

                result = MapToModel(initialResult);
            }

            return result;
        }

        /// <summary>
        /// Páginação base da entidade.
        /// </summary>
        /// <param name="page">Qual a página ele esta atualmente.</param>
        /// <param name="parameters">Itens a ser filtrado no select.</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntityModel> GetPaginated(int page, Expression<Func<TEntity, TEntityModel>> parameters = null)
        {
            int index = page * 12;
            ICollection<TEntityModel> result = null;
            if (parameters != null)
            {
                result = _context.Set<TEntity>()
                    .Skip(index)
                    .Take(12)
                    .Select(parameters)
                    .ToList();
            }
            else
            {
                var initialResult = _context.Set<TEntity>()
                    .Skip(index)
                    .Take(12)
                    .ToList();

                result = new List<TEntityModel>();
                foreach (var item in initialResult)
                {
                    result.Add(MapToModel(item));
                }
            }
            return result;
        }

        /// <summary>
        /// Validação base para novas entidade a ser inserida no banco, sobreescrever para validações especificas.
        /// </summary>
        /// <param name="object">objeto a ser inserido.</param>
        /// <returns>retorna o resultado da validação.</returns>
        protected virtual bool ValidateNewEntity(TEntityModel @object)
        {
            try
            {
                var newEntity = MapToEntity(@object);
                newEntity.Validate(_erros);
                return _erros.Any();
            }
            catch (ApplicationException)
            {
                throw;
            }
        }

        ///// <summary>
        ///// Validação base para entidades existêntes para ser atualizadas no banco, sobreescrever para validações especificas.
        ///// </summary>
        ///// <param name="object">Entidade a ser atualizada.</param>
        ///// <returns>retorna o resultado da validação.</returns>
        //public virtual bool ValidateExistingEntity(TEntityModel @object)
        //{
        //    try
        //    {
        //        var newEntity = MapToEntity(@object);
        //        newEntity.Validate(_erros);
        //        return _erros.Any();
        //    }
        //    catch (ApplicationException)
        //    {
        //        throw;
        //    }
        //}

        protected virtual TEntityModel MapToModel(TEntity entity)
        {
            if (entity != null)
            {
                return MapBase<TEntityModel, TEntity>.MapEntityModel(entity);
            }
            throw new ApplicationException();
        }

        protected virtual TEntity MapToEntity(TEntityModel model)
        {
            if (model != null)
            {
                return MapBase<TEntityModel, TEntity>.MapEntity(model);
            }
            throw new ApplicationException();
        }
    }
}
