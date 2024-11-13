using System.Text.Json.Serialization;

namespace qualityPointBackendTest.Dto;

public class DaDataAddress
{
     [JsonPropertyName("country")] public string Country { get; set; } = string.Empty;
     [JsonPropertyName("city")] public string City { get; set; } = string.Empty;
     [JsonPropertyName("street")] public string Street { get; set; } = string.Empty;
     [JsonPropertyName("house")] public string House { get; set; } = string.Empty;
     [JsonPropertyName("result")] public string Result { get; set; } = string.Empty;
}