using System.ComponentModel;

namespace Menu.Domain.Enum
{
    public enum UnitOfTemperature
    {
        [Description("Outra escala")]
        Other = 0,
        [Description("Escala Kelvin")]
        Kelvin = 1,
        [Description("Escala Celsius")]
        Celsius = 2,
        [Description("Escala Fahrenheit")]
        Fahrenheit = 3
    }
}
