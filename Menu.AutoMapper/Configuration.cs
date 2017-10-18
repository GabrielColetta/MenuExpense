using AutoMapper;

namespace Menu.AutoMapper
{
    public static class Configuration
    {
        public static void AutoMapperConfig()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToModelConfiguration>();
                x.AddProfile<ModelToEntityConfiguration>();
            });
        }
    }
}
