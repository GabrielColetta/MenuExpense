using AutoMapper;
using Menu.Domain.Dto;
using Menu.Domain.Entities;

namespace Menu.AutoMapper
{
    public class ModelToEntityConfiguration : Profile
    {
        public ModelToEntityConfiguration()
        {
            MapCook();
        }

        private void MapCook()
        {
            CreateMap<CookModel, Cook>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id));
        }
    }
}
