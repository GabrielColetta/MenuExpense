using Menu.Domain.Entities.Associations;
using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Ingredient : EntityBase
    {
        public string Name { get; set; }
        public long LocalStorageCount { get; set; }
        public string Brand { get; set; }

        public long? ConsolidationId { get; set; }
        public virtual Consolidation Consolidation { get; set; }

        public long? WeightId { get; set; }
        public virtual Weight Weight { get; set; }

        public long PriceId { get; set; }
        public virtual Price Price { get; set; }
        
        public virtual ICollection<IngredientDistributor> Distributors { get; set; }
    }
}
