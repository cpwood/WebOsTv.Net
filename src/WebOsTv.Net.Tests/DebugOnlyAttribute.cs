using System.Diagnostics;
using Xunit;

namespace WebOsTv.Net.Tests
{
    internal class DebugOnlyAttribute : FactAttribute
    {
        public override string Skip
        {
            get => Debugger.IsAttached ? null : "Not running in debug.";
            set {}
        }
    }
}
