using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Ystari.Serialization;
using System;

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

        void ISerializable.GetState(SerializationInfo target)
        {
            target.AddValue("v", Value);
            target.AddValue("c", HasChanged);
        }

        void ISerializable.SetState(SerializationInfo source)
        {
            Value = source.GetObject<T>("v");
            HasChanged = source.GetBool("c");
        }
    }

    public interface IObjectState : IEnumerable<IObjectState>, ISerializable
    {
        int GraphId { get; set; }
        bool HasChanged { get; }
    }

    public class ObjectState : IObjectState
    {
        int IObjectState.GraphId { get; set; }

        public bool HasChanged { get; private set; }

        public IEnumerable<IPropertyState> Properties { get; set; }

        void ISerializable.GetState(SerializationInfo target)
        {
            throw new NotImplementedException();
        }

        void ISerializable.SetState(SerializationInfo source)
        {
            throw new NotImplementedException();
        }

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
