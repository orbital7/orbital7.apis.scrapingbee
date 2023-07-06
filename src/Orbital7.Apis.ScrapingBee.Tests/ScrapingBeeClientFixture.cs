namespace Orbital7.Apis.ScrapingBee.Tests;

public class ScrapingBeeClientFixture
{
    private UserSecretsConfig Config { get; set; }

    public IScrapingBeeClient Client { get; private set; }

    public ScrapingBeeClientFixture()
    {
        this.Config = ConfigurationHelper.GetConfigurationWithUserSecrets<UserSecretsConfig, ScrapingBeeClientFixture>();
        this.Client = new ScrapingBeeClient(this.Config?.ScrapingBeeApiKey);
    }

    public void EnsureConfigurationLoaded()
    {
        if (this.Config == null || !this.Config.ScrapingBeeApiKey.HasText())
        {
            throw new Exception("No ScrapingBee API Key is specified in this project's User Secrets configuration");
        }
    }
}
