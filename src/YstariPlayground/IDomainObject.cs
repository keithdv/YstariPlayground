using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Ystari.Serialization;
using Ystari.StateManagement;

namespace Ystari
{
    public interface IDomainObject : ISerializable
    {
        int GraphId { get; set; }
    }

    public class DomainObject : SerializableObject, IDomainObject
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
        void ISerializable.GetState(SerializationInfo target)
        {
            GetState(target);
        }

        /// <summary>
        /// Override to put your state into the serialization stream.
        /// </summary>
        /// <param name="target">Serialization stream where you
        /// will put your state.</param>
        protected virtual void GetState(SerializationInfo target)
        { }

        void ISerializable.SetState(SerializationInfo source)
        {
            SetState(source);
        }

        /// <summary>
        /// Override to update your state with information from the
        /// serialization stream.
        /// </summary>
        /// <param name="source">Serialization stream containing your state.</param>
        protected virtual void SetState(SerializationInfo source)
        { }

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
}
