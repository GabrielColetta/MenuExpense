using System.Collections.Generic;

namespace Menu.Domain.Entities
{
    public class Cook : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
