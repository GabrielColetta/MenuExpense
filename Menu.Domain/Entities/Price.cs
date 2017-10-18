namespace Menu.Domain.Entities
{
    public class Price : EntityBase
    {
        public decimal PriceValue { get; set; }
        public decimal PricePerGramsOrMilliliters { get; set; }
        public decimal PricePerkilogramOrLiter { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
