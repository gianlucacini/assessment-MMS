using Assessment.Console.Models;

namespace Assessment.Console.BusinessLogic
{
    public interface IReader
    {
        IEnumerable<ICsv> GetUsersFromCsv();
    }
}