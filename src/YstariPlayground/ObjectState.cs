using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Ystari.Serialization;

namespace Ystari.ObjectState
{
    public interface IPropertyState : ISerializable
    {
        object GetPropertyValue();
        void SetValue(object value);
        bool HasChanged { get; set; }
    }

    public interface IPropertyState<T> : IPropertyState
    {
        T GetValue();
        void SetValue(T value);
    }

    public class PropertyState<T> : IPropertyState<T>
    {
        private T Value;
        public bool HasChanged { get; set; }

        public object GetPropertyValue()
        {
            return GetValue();
        }

        public void SetValue(object value)
        {
            SetValue((T)value);
        }

        public T GetValue()
        {
            return Value;
        }

        public void SetValue(T value)
        {
            if (!Value.Equals(value))
                HasChanged = true;
            Value = value;
        }
    }

    public interface IObjectState : ISerializable
    {
        int GraphId { get; set; }
        bool HasChanged { get; }
    }

    public class ObjectState : IObjectState
    {
        public bool HasChanged
        {
            get
            {
                return Properties.FirstOrDefault(_ => _.HasChanged) != null;
            }
        }

        public IEnumerable<IPropertyState> Properties { get; set; }

        int IObjectState.GraphId { get; set; }
    }

    public interface IObjectStateList : IEnumerable<IObjectState>, ISerializable
    {
        int GraphId { get; set; }
    }

    public class ObjectStateList : IObjectStateList
    {
        int IObjectStateList.GraphId { get; set; }

        public IEnumerable<IObjectState> List { get; set; }

        public IEnumerator<IObjectState> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }
    }
}
