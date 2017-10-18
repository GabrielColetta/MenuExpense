using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Recipe : EntityBase
    {
        public string Name { get; set; }
        public string Observations { get; set; }

        public long? TotalWeightId { get; set; }
        public virtual Weight TotalWeight { get; set; }

        public long? TotalCostId { get; set; }
        public virtual Cost TotalCost { get; set; }

        public long? SalePriceId { get; set; }
        public virtual Price SalePrice { get; set; }

        public long CookId { get; set; }
        public virtual Cook Cook { get; set; }

        public virtual ICollection<ProductionInput> ProductionInputs { get; set; }

        public override bool Validate(IEnumerable<string> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}
