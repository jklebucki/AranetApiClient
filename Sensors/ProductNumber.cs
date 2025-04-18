namespace AranetApiClient.Sensors;
public class ProductNumber
{
    public string Single { get; set; } = string.Empty;
    public Dictionary<string, string> Multiple { get; set; } = new Dictionary<string, string>();
    public bool IsMultiple => Multiple != null;
}
