namespace Ystari.Serialization
{
    public interface ISerializable
    { }

    public class ObjectStateFormatter
    {
        public byte[] Serialize(ISerializable rootObject)
        { return null; }

        public T Deserialize<T>(byte[] serializedData)
        { return default(T); }
    }
}
