namespace Menu.Domain.Entities.Associations
{
    /// <summary>
    /// Classe responsável no relacionamento Many to Many da ORM entre Ingrediente e Distribuidor.
    /// </summary>
    public class IngredientDistributor
    {
        public long IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public long DistributorId { get; set; }
        public Distributor Distributor { get; set; }
    }
}
