using System.Text.Json;
using System.Text.Json.Serialization;

namespace AranetApiClient.Sensors;

public class ProductNumberConverter : JsonConverter<ProductNumber>
{
    public override ProductNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var productNumber = new ProductNumber();

        if (reader.TokenType == JsonTokenType.String)
        {
            productNumber.Values.Add(reader.GetString() ?? string.Empty);
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            using var obj = JsonDocument.ParseValue(ref reader);

            var sorted = obj.RootElement
                .EnumerateObject()
                .OrderBy(p => int.TryParse(p.Name, out var num) ? num : int.MaxValue);

            foreach (var prop in sorted)
            {
                productNumber.Values.Add(prop.Value.GetString() ?? string.Empty);
            }
        }
        else
        {
            throw new JsonException("Invalid productNumber format");
        }

        return productNumber;
    }

    public override void Write(Utf8JsonWriter writer, ProductNumber value, JsonSerializerOptions options)
    {
        if (value.Values.Count == 1)
        {
            writer.WriteStringValue(value.Values[0]);
        }
        else
        {
            writer.WriteStartObject();
            for (int i = 0; i < value.Values.Count; i++)
            {
                writer.WriteString(i.ToString(), value.Values[i]);
            }
            writer.WriteEndObject();
        }
    }
}
