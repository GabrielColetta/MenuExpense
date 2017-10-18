using Menu.Domain.Entities.Associations;
using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Distributor : EntityBase
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        
        public virtual ICollection<IngredientDistributor> Ingredients { get; set; }

        public override bool Validate(IEnumerable<string> errors)
        {
            throw new System.NotImplementedException();
        }
    }
}
