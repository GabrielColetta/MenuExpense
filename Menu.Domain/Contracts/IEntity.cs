using System;
using System.Collections.Generic;

namespace Menu.Domain.Contracts
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime IncludedDate { get; set; }
        bool Validate(IEnumerable<string> errors);
    }
}
