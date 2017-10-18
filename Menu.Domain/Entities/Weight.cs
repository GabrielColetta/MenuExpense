using System.Collections.Generic;
using Menu.Domain.Enum;

namespace Menu.Domain.Entities
{
    public class Weight : EntityBase
    {
        public decimal Unit { get; set; }
        public UnitOfVolume UnitOfMeasurement { get; set; }
        public UnitOfVolumeType UnitOfMeasurementType { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Consolidation Consolidation { get; set; }
        public virtual ProductionInput ProductionInput { get; set; }
        public virtual Recipe Recipe { get; set; }

        public override bool Validate(IEnumerable<string> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}
