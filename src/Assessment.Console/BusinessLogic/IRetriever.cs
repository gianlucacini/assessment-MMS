using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IRetriever
    {
        IAsyncEnumerable<User> GetCompleteUsers(IEnumerable<ICsv> users);
    }
}