namespace Orbital7.Apis.ScrapingBee;

public interface IScrapingBeeClient
{
    Task<ContentResponse> ScrapeAsync(
        ScrapeRequest scrapeRequest);

    Task<UsageResponse> UsageAsync();
}
