using NUnit.Framework;
using Ystari.StateManagement;

namespace YstartTest
{
    [TestFixture]
    public class SerializePropertyStateTests
    {
        [TestCase("a", 123, false)]
        [TestCase("b", 321, true)]
        public void SerializePropertyState(string key, int value, bool hasChanged)
        {
            var state = new PropertyState<int> { Key = key, Value = value, HasChanged = hasChanged };
            Assert.That(state.HasChanged, Is.EqualTo(hasChanged));
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            Assert.That(result, Is.Not.Null.Or.Empty);
        }

        [TestCase("a", 123, false)]
        [TestCase("b", 321, true)]
        public void DeSerializePropertyState(string key, int value, bool hasChanged)
        {
            var state = new PropertyState<int> { Key = key, Value = value, HasChanged = hasChanged };
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            var final = Newtonsoft.Json.JsonConvert.DeserializeObject<PropertyState<int>>(result);
            Assert.That(final, Is.Not.Null);
            Assert.That(final.Key, Is.EqualTo(key));
            Assert.That(final.Value, Is.EqualTo(value));
            Assert.That(final.HasChanged, Is.EqualTo(hasChanged));
        }
    }
}
