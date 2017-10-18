using Menu.Domain.Contracts.Application;
using System;
using Menu.Domain.Entities;
using Menu.Domain.Contracts;

namespace Menu.Application
{
    public class IngredientApplication : IIngredientApplication
    {
        public IngredientApplication(IMenuContext context)
        {
            _context = context;
        }

        private readonly IMenuContext _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public void ValidateExistingEntity(Ingredient obj)
        {
            throw new NotImplementedException();
        }

        public void ValidateNewEntity(Ingredient obj)
        {
            throw new NotImplementedException();
        }
    }
}
