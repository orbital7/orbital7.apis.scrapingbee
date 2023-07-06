namespace Orbital7.Apis.ScrapingBee.Tests;

public class ScrapingBeeClientTests :
    IClassFixture<ScrapingBeeClientFixture>
{
    private ScrapingBeeClientFixture Fixture { get; set; }

    public ScrapingBeeClientTests(
        ScrapingBeeClientFixture fixture)
    {
        this.Fixture = fixture;
        this.Fixture.EnsureConfigurationLoaded();
    }

    [Fact]
    public async Task TestUsage()
    {
        var response = await this.Fixture.Client.UsageAsync();

        Assert.NotNull(response.CurrentConcurrency);
        Assert.NotNull(response.MaxApiCredit);
        Assert.NotNull(response.MaxConcurrency);
        Assert.NotNull(response.RenewalSubscriptionDate);
        Assert.NotNull(response.UsedApiCredit);
    }

    [Fact]
    public async Task TestBasicScrape()
    {
        var response = await this.Fixture.Client.ScrapeAsync(
            new ScrapeRequest("https://www.scrapingbee.com/")
            { 
                RenderJs = false,
            });

        Assert.NotNull(response.Cost);
        Assert.NotNull(response.Content);
        Assert.NotNull(response.InitialStatusCode);
        Assert.NotNull(response.ResolvedUrl);
    }
}