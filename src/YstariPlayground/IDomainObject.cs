using System.Collections.ObjectModel;
using Ystari.StateManagement;

namespace Ystari
{
    public interface IDomainObject
    {
        int GraphId { get; set; }
    }

    public class DomainObject : IDomainObject
    {
        int IDomainObject.GraphId { get; set; }

        private ObjectState MyState { get; set; }

        protected void SetProperty(IPropertyInfo property, object value, bool bypassAuthorization = false)
        {
            MyState.SetProperty(property.Name, value);
        }

        protected T GetProperty<T>(IPropertyInfo property, bool bypassAuthorization = false)
        {
            return MyState.GetProperty<T>(property.Name);
        }
    }

    public class DomainList<T> : ObservableCollection<T>, IDomainObject
        where T : IDomainObject
    {
        int IDomainObject.GraphId { get; set; }

        private ObjectState MyState { get; set; }

        protected void SetProperty(IPropertyInfo property, object value, bool bypassAuthorization = false)
        {
            MyState.SetProperty(property.Name, value);
        }

        protected P GetProperty<P>(IPropertyInfo property, bool bypassAuthorization = false)
        {
            return MyState.GetProperty<P>(property.Name);
        }
    }
}
