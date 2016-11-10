using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ystari.PropertyManagement
{
    public interface IPropertyManager
    {

    }

    public interface IPropertyManager<T>
    {
        IPropertyInfo<P> RegisterProperty<P>(Expression<Func<T, object>> propertyExpression);
        IPropertyInfo<P> RegisterPropertyByName<P>(string propertyName);
    }

    public class PropertyManager<T> : IPropertyManager<T>
    {
        public IPropertyInfo<P> RegisterProperty<P>(Expression<Func<T, object>> propertyExpression)
        {
            return new PropertyInfo<P>();
        }

        public IPropertyInfo<P> RegisterPropertyByName<P>(string propertyName)
        {
            return new PropertyInfo<P>();
        }
    }
}
