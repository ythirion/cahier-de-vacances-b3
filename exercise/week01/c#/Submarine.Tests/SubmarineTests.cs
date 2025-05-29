using FluentAssertions;
using Xunit;

namespace Submarine.Tests
{
    public class SubmarineTests
    {
        [Fact]
        // TODO find the right result by implementing the Submarine logic
        public void Should_Move_On_Given_Text_Instructions()
            => 43.Should()
                .Be(42, "it is universal answer");
    }
}