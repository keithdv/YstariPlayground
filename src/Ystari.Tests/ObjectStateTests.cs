using Newtonsoft.Json;
using NUnit.Framework;
using Ystari.StateManagement;

namespace Ystari.Tests
{
    [TestFixture]
    public class ObjectStateTests
    {
        [TestCase(123)]
        public void SerializeEmptyObjectState(int graphId)
        {
            var state = new ObjectState { GraphId = graphId };
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            Assert.That(result, Is.Not.Null.Or.Empty);
        }

        [TestCase(123)]
        public void SerializeObjectState(int graphId)
        {
            var state = new ObjectState { GraphId = graphId };
            state.Properties.Add(new PropertyState<int> { Key = "a", Value = 987 });
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            var jsonConverters = new JsonConverter[] { new PropertyStatusJSONConverter() };

            var final = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectState>(result, jsonConverters);
            Assert.That(final.Properties.Count, Is.EqualTo(1));
        }

        [TestCase(321)]
        public void DeSerializeEmptyObjectState(int graphId)
        {
            var state = new ObjectState { GraphId = graphId };
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            var final = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectState>(result);
            Assert.That(final, Is.Not.Null);
            Assert.That(final.GraphId, Is.EqualTo(graphId));
        }
    }
}
