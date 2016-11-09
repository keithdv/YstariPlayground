using System;
using System.Collections.Generic;

namespace Ystari.Serialization
{
    public interface ISerializable
    {
        void GetState(SerializationInfo target);
        void SetState(SerializationInfo source);
    }

    public class SerializationField
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string TypeName { get; set; }
    }

    public class SerializationInfo : List<SerializationField>
    {
        public void AddValue(string key, object value)
        {
            AddValue(key, value.ToString());
        }

        public void AddValue(string key, string value)
        {
            AddValue(key, value, "string");
        }

        private void AddValue(string key, string value, string typeName)
        {
            Add(new SerializationField { Key = key, Value = value, TypeName = typeName });
        }

        public void AddValue(string key, bool value)
        {
            AddValue(key, value.ToString(), "bool");
        }

        public object GetObject(string key)
        {
            throw new NotImplementedException();
        }

        public T GetObject<T>(string key)
        {
            return (T)GetObject(key);
        }

        public bool GetBool(string key)
        {
            throw new NotImplementedException();
        }
    }

    public class ObjectStateFormatter
    {
        public byte[] Serialize(ISerializable rootObject)
        { return null; }

        public T Deserialize<T>(byte[] serializedData)
        { return default(T); }
    }
}
