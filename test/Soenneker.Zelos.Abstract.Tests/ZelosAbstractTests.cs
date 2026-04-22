using Soenneker.Tests.HostedUnit;

namespace Soenneker.Zelos.Abstract.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ZelosAbstractTests : HostedUnitTest
{
    public ZelosAbstractTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
