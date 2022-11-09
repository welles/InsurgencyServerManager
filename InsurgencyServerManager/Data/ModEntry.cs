using Newtonsoft.Json;

namespace InsurgencyServerManager.Data;

[JsonObject]
public class ModEntry
{
    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("id")]
    public long? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("link")]
    public string? Link { get; set; }

    [JsonProperty("type")]
    public ModType Type { get; set; }
}
