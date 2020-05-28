using Newtonsoft.Json.Linq;
using WebOsTv.Net.Commands;
using Xunit;

namespace WebOsTv.Net.Tests.Commands
{
    public class CommandBaseTests
    {
        [Fact]
        public void CommandSerialisesSuccessfully()
        {
            var command = new TestCommandBase();
            var obj = command.ToJObject();

            Assert.NotNull(obj);
            Assert.Equal("Bar", obj["foo"].Value<string>());
            Assert.Null(obj["url"]);
        }

        private class TestCommandBase : CommandBase
        {
            public override string Uri => "foo";
            public string Foo { get; set; } = "Bar";
        }
    }
}
