[![](https://img.shields.io/nuget/v/soenneker.render.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.render.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.render.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.render.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.render.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.render.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.render.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.render.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Render.HttpClients

Provides a cached `HttpClient` for managing Render services, deploys, datastores, projects, environments, logs, and other account resources.

## Installation

```bash
dotnet add package Soenneker.Render.HttpClients
```

## Configuration

```json
{
  "Render": {
    "ApiKey": "your-render-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Render.HttpClients.Abstract;
using Soenneker.Render.HttpClients.Registrars;

services.AddRenderOpenApiHttpClientAsSingleton();

public sealed class RenderServiceReader
{
    private readonly IRenderOpenApiHttpClient _render;

    public RenderServiceReader(IRenderOpenApiHttpClient render)
    {
        _render = render;
    }

    public async Task<string> GetServices(CancellationToken cancellationToken)
    {
        HttpClient client = await _render.Get(cancellationToken);
        return await client.GetStringAsync("services?limit=3", cancellationToken);
    }
}
```

The provider uses `https://api.render.com/v1/` and sends the key as `Authorization: Bearer <api-key>`. `Render:ClientBaseUrl`, `Render:AuthHeaderName`, and `Render:AuthHeaderValueTemplate` can override those defaults for a proxy or compatible service; use `{token}` in the value template where the configured key should be inserted.
