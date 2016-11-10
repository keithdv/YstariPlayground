using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari
{
    public interface IPropertyInfo
    {
        string Name { get; }
    }

    public interface IPropertyInfo<T> : IPropertyInfo
    {
    }
}
