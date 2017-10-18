using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class ProductionInput : EntityBase
    {
        public string Name { get; set; }

        public long TotalWeightId { get; set; }
        public virtual Weight TotalWeight { get; set; }

        public virtual ICollection<Consolidation> Consolidations { get; set; }
    }
}
