using Menu.Domain.Enum;
using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Consolidation : EntityBase
    {
        public string Observations { get; set; }
        public virtual UnitOfVolume UnitOfVolume { get; set; }

        public long TotalWeightId { get; set; }
        public virtual Weight TotalWeight { get; set; }
        public long CostId { get; set; }
        public virtual Cost Cost { get; set; }
        public long ProductInputId { get; set; }
        public virtual ProductionInput ProductionInput { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public override bool Validate(IEnumerable<string> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}
