using AutoMapper;
using Menu.Domain.Dto;
using Menu.Domain.Entities;

namespace Menu.AutoMapper
{
    public class EntityToModelConfiguration : Profile
    {
        public EntityToModelConfiguration()
        {

        }

        private void MapCook()
        {
            CreateMap<Cook, CookModel>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id));
        }
    }
}
