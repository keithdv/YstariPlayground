
namespace Ystari.StateManagement
{
    public interface IPropertyState
    {
        string Name { get; }
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
        public string Name { get; set; }

        private T _value = default(T);
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

        public bool HasChanged { get; internal set; }

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
