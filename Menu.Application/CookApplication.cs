using Menu.Domain.Contracts.Application;
using Menu.Domain.Entities;
using Menu.Domain.Contracts;
using Menu.Domain.Dto;

namespace Menu.Application
{
    class CookApplication : ApplicationBase<CookModel, Cook>, ICookApplication
    {
        public CookApplication(IMenuContext context)
            : base(context)
        {
        }
    }
}
