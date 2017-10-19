using System;
using System.Collections.Generic;
using System.Text;

namespace Menu.Domain.Validations
{
    public class PropertyBuild
    {
        public PropertyBuild(object property)
        {

        }

        public virtual PropertyBuild IsRequired(bool required = true)
        {
            return this;
        }

        public virtual PropertyBuild HasMaxLength(long maxLength)
        {
            return this;
        }
    }
}
