using System;
using System.Collections.Generic;
using System.Linq;

namespace Ystari.Serialization
{
    public interface ISerializable
    {
        void GetState(SerializationInfo target);
        void SetState(SerializationInfo source);
    }

    public class SerializationField
    {
        public int GraphId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string TypeName { get; set; }
    }

    public class SerializationInfo : List<SerializationField>
    {
        public void AddValue<T>(string key, T value)
        {
            AddValue(key, value.ToString(), typeof(T).Name);
        }

        public void AddString(string key, string value)
        {
            AddValue(key, value, "s");
        }

        public void AddBool(string key, bool value)
        {
            AddValue(key, value.ToString(), "b");
        }

        public void AddInt32(string key, int value)
        {
            AddValue(key, value.ToString(), "i32");
        }

        private void AddValue(string key, string value, string typeName)
        {
            var existing = this.FirstOrDefault(_ => _.Key == key);
            if (existing != null)
                existing.Value = value;
            else
                Add(new SerializationField { Key = key, Value = value, TypeName = typeName });
        }

        public object GetObject(string key)
        {
            throw new NotImplementedException();
        }

        internal string GetString(string v)
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

        internal int GetInt32(string v)
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
