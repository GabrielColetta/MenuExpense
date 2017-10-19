using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Menu.Domain.Contracts.Pattern;
using Menu.Domain.Validations;

namespace Menu.Domain.Entities
{
    public class Cook : EntityBase, ILegitimize<Cook>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public void IsSatisfiedBy(LegitimizeCandidateBuilder<Cook> candidate)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(IEnumerable<string> errors)
        {
            return true;
        }

        public void Validate(LegitimizeCandidateBuilder<Cook> candidate)
        {
            throw new NotImplementedException();
        }
    }
}
