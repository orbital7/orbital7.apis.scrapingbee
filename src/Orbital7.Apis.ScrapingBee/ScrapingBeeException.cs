namespace Orbital7.Apis.ScrapingBee;

public class ScrapingBeeException : 
    Exception
{
    public HttpStatusCode StatusCode { get; private set; }

    public string ErrorJson { get; private set; }

    public ScrapingBeeException(
        HttpStatusCode statusCode,
        string errorJson)
    {
        this.StatusCode = statusCode;
        this.ErrorJson = errorJson;
    }

    public override string ToString()
    {
        return $"ERROR {(int)this.StatusCode} {this.StatusCode}";
    }
}
