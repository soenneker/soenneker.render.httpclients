using Soenneker.Render.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Render.HttpClients.Tests;

[Collection("Collection")]
public sealed class RenderOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IRenderOpenApiHttpClient _httpclient;

    public RenderOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IRenderOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
