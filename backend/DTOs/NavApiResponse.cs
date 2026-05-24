using System.Text.Json.Serialization;

namespace backend.DTOs;

public class NavApiResponse
{
    [JsonPropertyName("items")]
    public List<NavItem> Items { get; set; } = new();
}

public class NavItem
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("_feed_entry")]
    public FeedEntry FeedEntry { get; set; } = new();
}

public class FeedEntry
{
    [JsonPropertyName("businessName")]
    public string BusinessName { get; set; } = string.Empty;

    [JsonPropertyName("municipal")]
    public string Municipal { get; set; } = string.Empty;
}