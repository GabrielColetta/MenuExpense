using System.ComponentModel;

namespace Menu.Domain.Enum
{
    public enum UnitOfTime
    {
        [Description("Outra unidade")]
        Other = 0,
        Segundo = 1,
        Minuto = 2,
        Hora = 3,
        Dia = 4,
        Semana = 5,
        Mes = 6,
        Ano = 7
    }
}
