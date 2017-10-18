using System.ComponentModel;

namespace Menu.Domain.Enum
{
    public enum UnitOfVolume
    {
        [Description("Outra magnitude")]
        Other = 0,
        [Description("Grama")]
        Gram = 1,
        [Description("miligrama")]
        Milligram = 2,
        [Description("Kilograma")]
        Kilogram = 3,
        [Description("Litro")]
        Liter = 4,
        [Description("Mililitro")]
        Milliliter = 5,
        [Description("Métros Cubicos")]
        CubicMeter = 6
    }
}
