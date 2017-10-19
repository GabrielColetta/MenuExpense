using Menu.Domain.Contracts.Pattern;
using Menu.Domain.Entities;
using System.Collections.Generic;

namespace Menu.Domain.Dto
{
    public class CookModel : IEntityModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
