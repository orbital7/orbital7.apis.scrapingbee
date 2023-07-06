namespace Orbital7.Apis.ScrapingBee;

public class UsageResponse
{
    [JsonPropertyName("max_api_credit")]
    public int? MaxApiCredit { get; set; }

    [JsonPropertyName("used_api_credit")]
    public int? UsedApiCredit { get; set; }

    [JsonPropertyName("max_concurrency")]
    public int? MaxConcurrency { get; set; }

    [JsonPropertyName("current_concurrency")]
    public int? CurrentConcurrency { get; set; }

    [JsonPropertyName("renewal_subscription_date")]
    public DateTime? RenewalSubscriptionDate { get; set; }
}
