using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Ystari.Serialization;
using System;

namespace Ystari.StateManagement
{
    public interface IPropertyState : ISerializable
    {
        string Name { get; }
        object GetPropertyValue();
        void SetValue(object value);
        bool HasChanged { get; set; }
    }

    public interface IPropertyState<T> : IPropertyState
    {
        T GetValue();
        void SetValue(T value);
    }

    public class PropertyState<T> : SerializableObject, IPropertyState<T>
    {
        public string Name { get; set; }
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

        protected override void GetState(SerializationInfo target)
        {
            target.AddString("n", Name);
            target.AddValue("v", Value);
            target.AddBool("c", HasChanged);
            base.GetState(target);
        }

        protected override void SetState(SerializationInfo source)
        {
            Name = source.GetString("n");
            Value = source.GetObject<T>("v");
            HasChanged = source.GetBool("c");
            base.SetState(source);
        }
    }

    public interface IObjectState : IEnumerable<IObjectState>, ISerializable
    {
        int GraphId { get; set; }
        bool HasChanged { get; }
    }

    public class ObjectState : SerializableObject, IObjectState
    {
        public void SetProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        int IObjectState.GraphId { get; set; }

        public bool HasChanged
        {
            get
            {
                var hasChanged = Properties.FirstOrDefault(_ => _.HasChanged);
                return (hasChanged != null);
            }
        }

        public IEnumerable<IPropertyState> Properties { get; set; }

        protected override void GetState(SerializationInfo target)
        {
            target.AddInt32("gid", ((IObjectState)this).GraphId);
            foreach (var item in Properties)
                item.GetState(target);
            base.GetState(target);
        }

        protected override void SetState(SerializationInfo source)
        {
            ((IObjectState)this).GraphId = source.GetInt32("gid");
            foreach (var item in source.Where(_ => _.Key != "gid"))
            {
                var p = new PropertyState<object>(); //TODO: create correct generic type
                //((ISerializable)p).SetState(item);
                //Properties.Append(new P)
            }
            base.SetState(source);
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

        internal T GetProperty<T>(string name)
        {
            return default(T); //TODO: implement this
        }
    }
}
