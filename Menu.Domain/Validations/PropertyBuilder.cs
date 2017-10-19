using System;
using System.Collections.Generic;
using System.Text;

namespace Menu.Domain.Validations
{
    public class PropertyBuilder<TProperty> : PropertyBuild where TProperty : class
    {
        public PropertyBuilder(TProperty property)
            : base(property)
        {
            _property = property;
        }

        public TProperty _property { get; set; }

        public new virtual PropertyBuilder<TProperty> IsRequired(bool required = true)
        {
            return (PropertyBuilder<TProperty>)base.IsRequired(required);
        }

        public new virtual PropertyBuilder<TProperty> HasMaxLength(long maxLength)
        {
            return (PropertyBuilder<TProperty>)base.HasMaxLength(maxLength);
        }
    }
}
