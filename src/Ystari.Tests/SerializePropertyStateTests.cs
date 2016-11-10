using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            state.HasChanged.Should().Be(hasChanged);
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            result.Should().NotBeNullOrWhiteSpace();
        }
    }
}
