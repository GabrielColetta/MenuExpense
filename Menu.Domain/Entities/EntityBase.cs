using Menu.Domain.Contracts.Pattern;
using System;
using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        public long Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public bool IsDeleted { get; set; }

        public abstract bool Validate(IEnumerable<string> erros);
    }
}
