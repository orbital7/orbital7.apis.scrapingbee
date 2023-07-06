# [orbital7.apis.scrapingbee](https://github.com/orbital7/orbital7.apis.scrapingbee)

.NET *Unofficial* library for [ScrapingBee API](https://scrapingbee.com)

**Nuget Package:**  [Orbital7.Apis.ScrapingBee](https://www.nuget.org/packages/Orbital7.Apis.ScrapingBee)

**Example usage:**

```c#
var scrapingBeeClient = new ScrapingBeeClient("YOUR-API-KEY");
var response = await scrapingBeeClient.ScrapeAsync(
    new ScrapeRequest("https://dotnet.microsoft.com/")
    {
	RenderJs = false,
    });
```

To run the included Unit Tests within Visual Studio:

1. Right-click on the Orbital7.Apis.ScrapingBee.Tests project and select **Manage User Secrets**.
2. Within the resulting file editor for **secrets.json**, create a json entry for "ScrapingBeeApiKey" and add your API Key as the value.
3. Run the unit tests via the **Test Explorer** window.
