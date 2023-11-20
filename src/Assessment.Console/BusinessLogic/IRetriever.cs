using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IRetriever
    {
        List<User> GetCompleteUsers(IEnumerable<ICsv> users);
    }
}