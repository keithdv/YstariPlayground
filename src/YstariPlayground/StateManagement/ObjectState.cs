using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ystari.StateManagement
{
    public interface IObjectState : IEnumerable<IPropertyState>
    {
        int GraphId { get; set; }
        bool HasChanged { get; }
    }

    public class ObjectState : IObjectState
    {
        public int GraphId { get; set; }

        public bool HasChanged
        {
            get
            {
                var hasChanged = List.FirstOrDefault(_ => _.HasChanged);
                return (hasChanged != null);
            }
        }

        private IEnumerable<IPropertyState> List { get; set; }

        public IEnumerator<IPropertyState> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public T GetProperty<T>(string name)
        {
            var property = List.FirstOrDefault(_ => _.Name == name) as IPropertyState<T>;
            if (property != null)
                return property.Value;
            else
                return default(T);
        }

        public void SetProperty<T>(string propertyName, T value)
        {
            var property = List.FirstOrDefault(_ => _.Name == propertyName) as IPropertyState<T>;
            if (property != null)
                property.Value = value;
            else
                List.Append(new PropertyState<T> { Name = propertyName, Value = value, HasChanged = false });
        }
    }
}
