using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari.Serialization
{
    /// <summary>
    /// Most primitive of the serializable types available
    /// </summary>
    public class SerializableObject : ISerializable
    {
        void ISerializable.GetState(SerializationInfo target)
        {
            GetState(target);
        }

        /// <summary>
        /// Override to put your state into the serialization stream.
        /// </summary>
        /// <param name="target">Serialization stream where you
        /// will put your state.</param>
        protected virtual void GetState(SerializationInfo target)
        { }

        void ISerializable.SetState(SerializationInfo source)
        {
            SetState(source);
        }

        /// <summary>
        /// Override to update your state with information from the
        /// serialization stream.
        /// </summary>
        /// <param name="source">Serialization stream containing your state.</param>
        protected virtual void SetState(SerializationInfo source)
        { }
    }
}
