using AspNetCoreRateLimit;
using Menu.Application;
using Menu.Data.Context;
using Menu.Domain.Contracts;
using Menu.Domain.Contracts.Application;
using Menu.Domain.Contracts.Pattern;
using Microsoft.Extensions.DependencyInjection;

namespace Menu.Api
{
    public partial class Startup
    {
        private void ApplicationService(IServiceCollection services)
        {
            //CONTEXTO
            services.AddTransient<IContext, MenuContext>();

            //COMPONENTES.
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            //SERVIÇOS
            services.AddTransient<IIngredientApplication, IngredientApplication>();
        }
    }
}
