using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ystari.StateManagement
{
    public class PropertyStatusJSONConverter : JsonConverter
    {

        public PropertyStatusJSONConverter() : base()
        {

        }


        public override bool CanConvert(Type objectType)
        {
            if(objectType.FullName == typeof(IPropertyState).FullName)
            {
                return true;
            }

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            JToken token = jObject[nameof(PropertyState<object>.PropertyType)];

            Type t = Type.GetType(token.Value<string>());

            return jObject.ToObject(typeof(PropertyState<>).MakeGenericType(t));

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
