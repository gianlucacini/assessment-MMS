namespace Assessment.Console.Models
{
    public interface ICsv
    {
        string? FamilyName { get; init; }
        string? GivenName { get; init; }
    }
}