using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ystari.StateManagement
{
    public interface IObjectState
    {
        int GraphId { get; }
        bool HasChanged { get; }
        List<IPropertyState> Properties { get; }
    }

    public class ObjectState : IObjectState
    {
        public ObjectState()
        {
            Properties = new List<IPropertyState>();
        }

        [Newtonsoft.Json.JsonRequired]
        public int GraphId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public bool HasChanged
        {
            get
            {
                var hasChanged = Properties.FirstOrDefault(_ => _.HasChanged);
                return (hasChanged != null);
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        List<IPropertyState> IObjectState.Properties
        {
            get
            {
                return Properties;
            }
        }

        public List<PropertyStatus> Properties { get; set; }

        public T GetProperty<T>(string name)
        {
            var property = Properties.FirstOrDefault(_ => _.Key == name) as IPropertyState<T>;
            if (property != null)
                return property.Value;
            else
                return default(T);
        }

        public void SetProperty<T>(string propertyName, T value)
        {
            var property = Properties.FirstOrDefault(_ => _.Key == propertyName) as IPropertyState<T>;
            if (property != null)
                property.Value = value;
            else
                Properties.Append(new PropertyState<T> { Key = propertyName, Value = value, HasChanged = false });
        }
    }
}
