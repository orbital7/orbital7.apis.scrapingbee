namespace Orbital7.Apis.ScrapingBee;

public class ScrapeRequest
{
    public string Url { get; set; }

    public bool? BlockAds { get; set; }

    public bool? BlockResources { get; set; }

    public string Cookies { get; set; }

    public string CountryCode { get; set; }

    public bool? CustomGoogle { get; set; }

    public string Device { get; set; }

    public string ExtractRules { get; set; }

    public bool? ForwardHeaders { get; set; }

    public bool? ForwardHeadersPure { get; set; }

    public string JsScenario { get; set; }

    public bool? JsonResponse { get; set; }

    public string OwnProxy { get; set; }

    public bool? PremiumProxy { get; set; }

    public bool? RenderJs { get; set; }

    public bool? ReturnPageSource { get; set; }

    public bool? Screenshot { get; set; }

    public bool? ScreenshotFullPage { get; set; }

    public string ScreenshotSelector { get; set; }

    public int? SessionId { get; set; }

    public bool? StealthProxy { get; set; }

    public int? Timeout { get; set; }

    public bool? TransparentStatusCode { get; set; }

    public int? Wait { get; set; }

    public string WaitBrowser { get; set; }

    public string WaitFor { get; set; }

    public int? WindowHeight { get; set; }

    public int? WindowWidth { get; set; }

    public ScrapeRequest(
        string url)
    {
        this.Url = url;
    }

    public string ToQueryString(
        string apiKey)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["api_key"] = apiKey;
        query["url"] = this.Url;

        if (this.BlockAds.HasValue)
            query["block_ads"] = this.BlockAds.Value.ToString();

        if (this.BlockResources.HasValue)
            query["block_resources"] = this.BlockResources.Value.ToString();

        if (this.Cookies.HasText())
            query["cookies"] = this.Cookies;

        if (this.CountryCode.HasText())
            query["country_code"] = this.CountryCode;

        if (this.CustomGoogle.HasValue)
            query["custom_google"] = this.CustomGoogle.Value.ToString();

        if (this.Device.HasText())
            query["device"] = this.Device;

        if (this.ExtractRules.HasText())
            query["extract_rules"] = this.ExtractRules;

        if (this.ForwardHeaders.HasValue)
            query["forward_headers"] = this.ForwardHeaders.Value.ToString();

        if (this.ForwardHeadersPure.HasValue)
            query["forward_headers_pure"] = this.ForwardHeadersPure.Value.ToString();

        if (this.JsScenario.HasText())
            query["js_scenario"] = this.JsScenario;

        if (this.JsonResponse.HasValue)
            query["json_response"] = this.JsonResponse.Value.ToString();

        if (this.OwnProxy.HasText())
            query["own_proxy"] = this.OwnProxy;

        if (this.PremiumProxy.HasValue)
            query["premium_proxy"] = this.PremiumProxy.Value.ToString();

        if (this.RenderJs.HasValue)
            query["render_js"] = this.RenderJs.Value.ToString();

        if (this.ReturnPageSource.HasValue)
            query["return_page_source"] = this.ReturnPageSource.Value.ToString();

        if (this.Screenshot.HasValue)
            query["screenshot"] = this.Screenshot.Value.ToString();

        if (this.ScreenshotFullPage.HasValue)
            query["screenshot_full_page"] = this.Screenshot.Value.ToString();

        if (this.ScreenshotSelector.HasText())
            query["screenshot_selector"] = this.ScreenshotSelector;

        if (this.SessionId.HasValue)
            query["session_id"] = this.SessionId.Value.ToString();

        if (this.StealthProxy.HasValue)
            query["stealth_proxy"] = this.StealthProxy.Value.ToString();

        if (this.Timeout.HasValue)
            query["timeout"] = this.Timeout.Value.ToString();

        if (this.TransparentStatusCode.HasValue)
            query["transparent_status_code"] = this.TransparentStatusCode.Value.ToString();

        if (this.Wait.HasValue)
            query["wait"] = this.Wait.Value.ToString();

        if (this.WaitBrowser.HasText())
            query["wait_browser"] = this.WaitBrowser;

        if (this.WaitFor.HasText())
            query["wait_for"] = this.WaitFor;

        if (this.WindowHeight.HasValue)
            query["window_height"] = this.WindowHeight.Value.ToString();

        if (this.WindowWidth.HasValue)
            query["window_width"] = this.WindowWidth.Value.ToString();

        return query.ToString();
    }
}
