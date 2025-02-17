using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Zelos.Abstract.Tests;

[Collection("Collection")]
public class ZelosAbstractTests : FixturedUnitTest
{
    public ZelosAbstractTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
