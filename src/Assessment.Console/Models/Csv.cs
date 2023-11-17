namespace Assessment.Console.Models;

public class Csv
{
    public Csv(string givenName, string familyName)
    {
        GivenName = givenName;
        FamilyName = familyName;
    }
    public string? GivenName { get; private set; }
    public string? FamilyName { get; private set; }
}