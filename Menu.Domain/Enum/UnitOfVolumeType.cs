using System.ComponentModel;

namespace Menu.Domain.Enum
{
    public enum UnitOfVolumeType
    {
        [Description("Outro tipo")]
        Other = 0,
        [Description("Sólidos")]
        Solid = 1,
        [Description("Líquidos")]
        Liquid = 2,
        [Description("Áridos")]
        Arid = 3
    }
}
