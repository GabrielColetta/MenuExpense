using System;
using System.Linq.Expressions;

namespace Menu.Domain.Validations
{
    public class LegitimizeCandidateBuilder<TCandidate> where TCandidate : class
    {
        public virtual PropertyBuilder<TProperty> Property<TProperty>(Expression<Func<TCandidate, TProperty>> propertyExpression)
            where TProperty : class
        {
            var candidate = propertyExpression.Compile().Invoke(_candidate);
            return new PropertyBuilder<TProperty>(candidate);
        }

        private readonly TCandidate _candidate;
    }
}
