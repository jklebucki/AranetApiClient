namespace AranetApiClient.Sensors;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ProductNumberConverter : JsonConverter<ProductNumber>
{
    public override ProductNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new ProductNumber { Single = reader.GetString()! };
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(ref reader, options);
            return new ProductNumber { Multiple = dict };
        }
        throw new JsonException("Unexpected token for ProductNumber");
    }

    public override void Write(Utf8JsonWriter writer, ProductNumber value, JsonSerializerOptions options)
    {
        if (value.IsMultiple)
            JsonSerializer.Serialize(writer, value.Multiple, options);
        else
            writer.WriteStringValue(value.Single);
    }
}
