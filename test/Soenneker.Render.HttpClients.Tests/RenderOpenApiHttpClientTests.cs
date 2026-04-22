using Soenneker.Render.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Render.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class RenderOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IRenderOpenApiHttpClient _httpclient;

    public RenderOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IRenderOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
