using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari.PropertyManagement
{
    public class PropertyInfo<T> : IPropertyInfo<T>
    {
        public string Name { get; private set; }
    }
}
