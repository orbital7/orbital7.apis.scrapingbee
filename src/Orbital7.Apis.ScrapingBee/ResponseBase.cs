namespace Orbital7.Apis.ScrapingBee;

public abstract class ResponseBase
{
    [JsonPropertyName("cost")]
    public int? Cost { get; set; }

    [JsonPropertyName("initial-status-code")]
    public int? InitialStatusCode { get; set; }

    [JsonPropertyName("resolved-url")]
    public string ResolvedUrl { get; set; }

    protected ResponseBase()
    {

    }

    protected ResponseBase(
        ResponseBase response)
    {
        this.Cost = response.Cost;
        this.InitialStatusCode = response.InitialStatusCode;
        this.ResolvedUrl = response.ResolvedUrl;
    }
}
