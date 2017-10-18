using System;

namespace Menu.Domain.Contracts
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime IncludedDate { get; set; }
    }
}
