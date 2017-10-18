using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Price : EntityBase
    {
        public decimal PriceValue { get; set; }
        public decimal PricePerGramsOrMilliliters { get; set; }
        public decimal PricePerkilogramOrLiter { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }

        public override bool Validate(IEnumerable<string> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}
