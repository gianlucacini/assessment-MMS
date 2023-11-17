namespace Assessment.Shared;

using System.Text.Json.Serialization;

public record User
{
    [JsonPropertyName("mail")] public string? Email { get; init; }
    [JsonPropertyName("given-name")] public string? GivenName { get; init; }
    [JsonPropertyName("family-name")] public string? FamilyName { get; init; }
}