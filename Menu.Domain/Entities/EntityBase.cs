using Menu.Domain.Contracts;
using System;

namespace Menu.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public long Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
