namespace Orbital7.Apis.ScrapingBee;

// Documentation: https://www.scrapingbee.com/documentation/
public class ScrapingBeeClient :
    IScrapingBeeClient
{
    private const string BASE_URL = "https://app.scrapingbee.com/api/v1/";

    private string ApiKey { get; set; }

    public ScrapingBeeClient(
        string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<ContentResponse> ScrapeAsync(
        ScrapeRequest scrapeRequest)
    {
        var url = $"{BASE_URL}?{scrapeRequest.ToQueryString(this.ApiKey)}";
        var response = await SendRequestAsync(url);
        return response;
    }

    public async Task<UsageResponse> UsageAsync()
    {
        var url = $"{BASE_URL}usage?api_key={this.ApiKey}";
        var response = await SendRequestAsync(url);
        return JsonSerializer.Deserialize<UsageResponse>(response.Content);
    }

    private async Task<ContentResponse> SendRequestAsync(
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
            
            if (response.IsSuccessStatusCode)
            {
                return new ContentResponse()
                {
                    Cost = GetSingularHeaderValueInteger(response, "Spb-cost"),
                    InitialStatusCode = GetSingularHeaderValueInteger(response, "Spb-initial-status-code"),
                    ResolvedUrl = GetSingularHeaderValue(response, "Spb-resolved-url"),
                    Content = responseContent,
                };
            }
            else
            {
                throw new ScrapingBeeException(
                    response.StatusCode,
                    responseContent);
            }
        }
    }

    private string GetSingularHeaderValue(
        HttpResponseMessage response,
        string headerKey)
    {
        var found = response.Headers.TryGetValues(headerKey, out IEnumerable<string> headerValues);
        if (found && headerValues != null && headerValues.Any())
        {
            return headerValues.First();
        }

        return null;
    }

    private int? GetSingularHeaderValueInteger(
        HttpResponseMessage response,
        string headerKey)
    {
        var headerValue = GetSingularHeaderValue(response, headerKey);
        if (headerValue.HasText())
        {
            return int.Parse(headerValue);
        }

        return null;
    }
}
