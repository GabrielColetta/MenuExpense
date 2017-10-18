using Menu.Application;
using Menu.Data.Context;
using Menu.Domain.Contracts;
using Menu.Domain.Contracts.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Menu.Api
{
    public partial class Startup
    {
        private void ApplicationService(IServiceCollection services)
        {
            //Contexto.
            services.AddTransient<IMenuContext, MenuContext>();

            //Serviços.
            services.AddTransient<IIngredientApplication, IngredientApplication>();
        }
    }
}
