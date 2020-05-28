using WebOsTv.Net.Commands;
using Xunit;

namespace WebOsTv.Net.Tests.Commands
{
    public class NoPayloadCommandBaseTests
    {
        [Fact]
        public void CommandSerialisesSuccessfully()
        {
            var command = new TestNoPayloadCommandBase();
            var obj = command.ToJObject();
            Assert.Null(obj);
        }

        private class TestNoPayloadCommandBase : NoPayloadCommandBase
        {
            public override string Uri => "foo";
        }
    }
}
