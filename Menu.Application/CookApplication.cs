using Menu.Domain.Contracts.Application;
using Menu.Domain.Entities;
using Menu.Domain.Dto;
using Menu.Domain.Contracts.Pattern;

namespace Menu.Application
{
    class CookApplication : ApplicationBase<CookModel, Cook>, ICookApplication
    {
        public CookApplication(IContext context)
            : base(context)
        {
        }
    }
}
