using Menu.Domain.Dto;
using Menu.Domain.Entities;

namespace Menu.Domain.Contracts.Application
{
    public interface ICookApplication : IApplicationBase<CookModel, Cook>
    {
    }
}
