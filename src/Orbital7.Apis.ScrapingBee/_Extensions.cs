namespace Orbital7.Apis.ScrapingBee;

static class Extensions
{
    public static bool HasText(
        this string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}