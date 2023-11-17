namespace Assessment.Console.Models;

public record Csv
{
    public Csv(string givenName, string familyName)
    {
        GivenName = givenName;
        FamilyName = familyName;
    }
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }
}