namespace Orbital7.Apis.ScrapingBee;

public class ScrapingBeeClient
{
    private const string BASE_URL = "https://app.scrapingbee.com/api/v1/";

    private string ApiKey { get; set; }

    public ScrapingBeeClient(
        string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<string> ScrapeAsync(
        ScrapeRequest scrapeRequest)
    {
        return await SendRequestAsync(GetUrl(scrapeRequest));
    }

    private string GetUrl(
        ScrapeRequest scrapeRequest)
    {
        return $"{BASE_URL}?{scrapeRequest.ToQueryString(this.ApiKey)}";
    }

    private async Task<string> SendRequestAsync(
        string url)
    {
        var httpClientHandler = new HttpClientHandler();
        if (httpClientHandler.SupportsAutomaticDecompression)
        {
            httpClientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        }

        var httpClient = new HttpClient(httpClientHandler);
        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
        };

        using (var response = await httpClient.SendAsync(httpRequest))
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                //var error = JsonSerializationHelper.DeserializeFromJson<ErrorResponse>(responseContent);
                //throw new Exception($"ERROR: {error.Error} ({error.Message})");
                throw new Exception("TODO: Parse error response");
            }
            else
            {
                return responseContent;
            }
        }
    }
}
