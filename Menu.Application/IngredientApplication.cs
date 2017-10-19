using Menu.Domain.Contracts.Application;
using Menu.Domain.Entities;
using Menu.Domain.Dto;
using Menu.Domain.Contracts.Pattern;

namespace Menu.Application
{
    public class IngredientApplication : ApplicationBase<IngredientModel, Ingredient>, IIngredientApplication
    {
        public IngredientApplication(IContext context)
            : base(context)
        {
        }
    }
}
