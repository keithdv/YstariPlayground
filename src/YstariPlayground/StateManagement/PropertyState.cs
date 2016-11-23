
namespace Ystari.StateManagement
{
    public interface IPropertyState
    {
        string Key { get; }
        object GetPropertyValue();
        void SetPropertyValue(object value);
        bool HasChanged { get; }
    }

    public interface IPropertyState<T> : IPropertyState
    {
        T Value { get; set; }
    }

    public class PropertyState<T> : IPropertyState<T>
    {
        [Newtonsoft.Json.JsonRequired]
        public string Key { get; set; }

        [Newtonsoft.Json.JsonRequired]
        private T _value = default(T);
        [Newtonsoft.Json.JsonIgnore]
        public T Value
        {
            get { return _value; }
            set
            {
                if (!_value.Equals(value))
                    HasChanged = true;
                _value = value;
            }
        }

        [Newtonsoft.Json.JsonRequired]
        public bool HasChanged { get; set; }

        [Newtonsoft.Json.JsonRequired]
        public System.Type PropertyType { get; private set; } = typeof(T);

        object IPropertyState.GetPropertyValue()
        {
            return Value;
        }

        void IPropertyState.SetPropertyValue(object value)
        {
            Value = (T)value;
        }
    }
}
